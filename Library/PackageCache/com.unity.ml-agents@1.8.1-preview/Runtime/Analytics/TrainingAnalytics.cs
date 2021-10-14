using System;
using System.Collections.Generic;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityEngine.Analytics;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Analytics;
#endif

namespace Unity.MLAgents.Analytics
{
    internal class TrainingAnalytics
    {
        const string k_VendorKey = "unity.ml-agents";
        const string k_TrainingEnvironmentInitializedEventName = "ml_agents_training_environment_initialized";
        const string k_TrainingBehaviorInitializedEventName = "ml_agents_training_behavior_initialized";
        const string k_RemotePolicyInitializedEventName = "ml_agents_remote_policy_initialized";

        private static readonly string[] s_EventNames =
        {
            k_TrainingEnvironmentInitializedEventName,
            k_TrainingBehaviorInitializedEventName,
            k_RemotePolicyInitializedEventName
        };

        /// <summary>
        /// Whether or not we've registered this particular event yet
        /// </summary>
        static bool s_EventsRegistered = false;

        /// <summary>
        /// Hourly limit for this event name
        /// </summary>
        const int k_MaxEventsPerHour = 1000;

        /// <summary>
        /// Maximum number of items in this event.
        /// </summary>
        const int k_MaxNumberOfElements = 1000;

        private static bool s_SentEnvironmentInitialized;
        /// <summary>
        /// Behaviors that we've already sent events for.
        /// </summary>
        private static HashSet<string> s_SentRemotePolicyInitialized;
        private static HashSet<string> s_SentTrainingBehaviorInitialized;

        private static Guid s_TrainingSessionGuid;

        // These are set when the RpcCommunicator connects
        private static string s_TrainerPackageVersion = "";
        private static string s_TrainerCommunicationVersion = "";

        static bool EnableAnalytics()
        {
            if (s_EventsRegistered)
            {
                return true;
            }

            foreach (var eventName in s_EventNames)
            {
#if UNITY_EDITOR
                AnalyticsResult result = EditorAnalytics.RegisterEventWithLimit(eventName, k_MaxEventsPerHour, k_MaxNumberOfElements, k_VendorKey);
#else
                AnalyticsResult result = AnalyticsResult.UnsupportedPlatform;
#endif
                if (result != AnalyticsResult.Ok)
                {
                    return false;
                }
            }
            s_EventsRegistered = true;

            if (s_SentRemotePolicyInitialized == null)
            {
                s_SentRemotePolicyInitialized = new HashSet<string>();
                s_SentTrainingBehaviorInitialized = new HashSet<string>();
                s_TrainingSessionGuid = Guid.NewGuid();
            }

            return s_EventsRegistered;
        }

        /// <summary>
        /// Cache information about the trainer when it becomes available in the RpcCommunicator.
        /// </summary>
        /// <param name="communicationVersion"></param>
        /// <param name="packageVersion"></param>
        public static void SetTrainerInformation(string packageVersion, string communicationVersion)
        {
            s_TrainerPackageVersion = packageVersion;
            s_TrainerCommunicationVersion = communicationVersion;
        }

        public static bool IsAnalyticsEnabled()
        {
#if UNITY_EDITOR
            return EditorAnalytics.enabled;
#else
            return false;
#endif
        }

        public static void TrainingEnvironmentInitialized(TrainingEnvironmentInitializedEvent tbiEvent)
        {
            if (!IsAnalyticsEnabled())
                return;

            if (!EnableAnalytics())
                return;

            if (s_SentEnvironmentInitialized)
            {
                // We already sent an TrainingEnvironmentInitializedEvent. Exit so we don't resend.
                return;
            }

            s_SentEnvironmentInitialized = true;
            tbiEvent.TrainingSessionGuid = s_TrainingSessionGuid.ToString();

            // Note - to debug, use JsonUtility.ToJson on the event.
            // Debug.Log(
            //     $"Would send event {k_TrainingEnvironmentInitializedEventName} with body {JsonUtility.ToJson(tbiEvent, true)}"
            // );
#if UNITY_EDITOR
            if (AnalyticsUtils.s_SendEditorAnalytics)
            {
                EditorAnalytics.SendEventWithLimit(k_TrainingEnvironmentInitializedEventName, tbiEvent);
            }
#else
            return;
#endif
        }

        public static void RemotePolicyInitialized(
            string fullyQualifiedBehaviorName,
            IList<ISensor> sensors,
            ActionSpec actionSpec,
            IList<IActuator> actuators
        )
        {
            if (!IsAnalyticsEnabled())
                return;

            if (!EnableAnalytics())
                return;

            // Extract base behavior name (no team ID)
            var behaviorName = ParseBehaviorName(fullyQualifiedBehaviorName);
            var added = s_SentRemotePolicyInitialized.Add(behaviorName);

            if (!added)
            {
                // We previously added this model. Exit so we don't resend.
                return;
            }

            var data = GetEventForRemotePolicy(behaviorName, sensors, actionSpec, actuators);
            // Note - to debug, use JsonUtility.ToJson on the event.
            // Debug.Log(
            //     $"Would send event {k_RemotePolicyInitializedEventName} with body {JsonUtility.ToJson(data, true)}"
            // );
#if UNITY_EDITOR
            if (AnalyticsUtils.s_SendEditorAnalytics)
            {
                EditorAnalytics.SendEventWithLimit(k_RemotePolicyInitializedEventName, data);
            }
#else
            return;
#endif
        }

        internal static string ParseBehaviorName(string fullyQualifiedBehaviorName)
        {
            var lastQuestionIndex = fullyQualifiedBehaviorName.LastIndexOf("?");
            if (lastQuestionIndex < 0)
            {
                // Nothing to remove
                return fullyQualifiedBehaviorName;
            }

            return fullyQualifiedBehaviorName.Substring(0, lastQuestionIndex);
        }

        public static void TrainingBehaviorInitialized(TrainingBehaviorInitializedEvent tbiEvent)
        {
            if (!IsAnalyticsEnabled())
                return;

            if (!EnableAnalytics())
                return;

            var behaviorName = tbiEvent.BehaviorName;
            var added = s_SentTrainingBehaviorInitialized.Add(behaviorName);

            if (!added)
            {
                // We previously added this model. Exit so we don't resend.
                return;
            }

            // Hash the behavior name so that there's no concern about PII or "secret" data being leaked.
            tbiEvent.TrainingSessionGuid = s_TrainingSessionGuid.ToString();
            tbiEvent.BehaviorName = AnalyticsUtils.Hash(tbiEvent.BehaviorName);

            // Note - to debug, use JsonUtility.ToJson on the event.
            // Debug.Log(
            //     $"Would send event {k_TrainingBehaviorInitializedEventName} with body {JsonUtility.ToJson(tbiEvent, true)}"
            // );
#if UNITY_EDITOR
            if (AnalyticsUtils.s_SendEditorAnalytics)
            {
                EditorAnalytics.SendEventWithLimit(k_TrainingBehaviorInitializedEventName, tbiEvent);
            }
#else
            return;
#endif
        }

        internal static RemotePolicyInitializedEvent GetEventForRemotePolicy(
            string behaviorName,
            IList<ISensor> sensors,
            ActionSpec actionSpec,
            IList<IActuator> actuators
        )
        {
            var remotePolicyEvent = new RemotePolicyInitializedEvent();

            // Hash the behavior name so that there's no concern about PII or "secret" data being leaked.
            remotePolicyEvent.BehaviorName = AnalyticsUtils.Hash(behaviorName);

            remotePolicyEvent.TrainingSessionGuid = s_TrainingSessionGuid.ToString();
            remotePolicyEvent.ActionSpec = EventActionSpec.FromActionSpec(actionSpec);
            remotePolicyEvent.ObservationSpecs = new List<EventObservationSpec>(sensors.Count);
            foreach (var sensor in sensors)
            {
                remotePolicyEvent.ObservationSpecs.Add(EventObservationSpec.FromSensor(sensor));
            }

            remotePolicyEvent.ActuatorInfos = new List<EventActuatorInfo>(actuators.Count);
            foreach (var actuator in actuators)
            {
                remotePolicyEvent.ActuatorInfos.Add(EventActuatorInfo.FromActuator(actuator));
            }

            remotePolicyEvent.MLAgentsEnvsVersion = s_TrainerPackageVersion;
            remotePolicyEvent.TrainerCommunicationVersion = s_TrainerCommunicationVersion;
            return remotePolicyEvent;
        }
    }
}
