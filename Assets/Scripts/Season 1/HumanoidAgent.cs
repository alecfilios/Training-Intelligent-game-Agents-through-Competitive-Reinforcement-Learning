using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors; // for CollectObservations()
using UnityEngine;

public class HumanoidAgent : Agent
{
    /**
     * Character Controller..!!
     */
    private CharacterController characterController;
    [SerializeField]
    private float movementSpeed, rotationSpeed, jumpSpeed, gravity;
    private Vector3 movementDirection = Vector3.zero;
    private bool playerIsGrounded;


    /**
     * Other Entities
     */
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private GameObject floor;

    /**
     * Some scales/sizes etc
     */
    private Vector3 floorMeshSize;
    private Vector3 floorLocalScale;
    private float floorRadius;
    private float floorHeight;
    /**
     * Animation
     */
    [SerializeField] private bool hasAnimation;
    private Animator animator;
    bool movedForward = false;
    bool movedBackwards = false;

    /*
     *  Constructor
     */
    public HumanoidAgent()
    {
    }

    public void Start()
    {

        if (hasAnimation)
        {
            animator = GetComponent<Animator>();
        }
        // Get the character controller
        characterController = GetComponent<CharacterController>();
        // Get the info of the floor for the randoms 
        floorMeshSize = floor.GetComponent<MeshFilter>().mesh.bounds.size;
        floorLocalScale = floor.transform.localScale;
        floorRadius = floorMeshSize.x * floorLocalScale.x / 2.0f;
        floorHeight = floorMeshSize.y * floorLocalScale.y / 2.0f;

    }
    /* 
     * Called at the beginning of an Agent's episode, including at the beginning of the simulation.
     */
    public override void OnEpisodeBegin()
    {
       
    }
    /*
     * Called every step that the Agent requests a decision. 
     * This is one possible way for collecting the Agent's observations of the environment; 
     */
    public override void CollectObservations(VectorSensor sensor)
    {

        /* Since the CollectObservations() method calls VectorSensor.AddObservation() such that vector size adds up to 8, 
         * the Behavior Parameters of the Agent are set with vector observation space with a state size of 8. 
         */
        // Knowloedge of it's own position [+3]
        sensor.AddObservation(transform.localPosition);
        // Knowloedge of it's own Y rotation [+1]
        sensor.AddObservation(transform.localRotation.y);
        // Knowloedge of the enemy's position [+3]
        sensor.AddObservation(targetTransform.localPosition);
        // Knowloedge of the goal's position [+3]
        sensor.AddObservation(enemyTransform.localPosition);

    }
    /*
     * Called every time the Agent receives an action to take. 
     * Receives the action chosen by the Agent.
     * It is also common to assign a reward in this method.
     */
    public override void OnActionReceived(ActionBuffers actions)
    {



        // Check whether the agent is grounded
        playerIsGrounded = characterController.isGrounded;
        // Verical movement (Forward & Backwards) 
        Vector3 inputMovement = transform.forward * movementSpeed * actions.ContinuousActions[0];
        // Apply it to the agents character controller and move
        characterController.Move(inputMovement * Time.deltaTime);
        // The rotation of the character comes from the Horizontal
        transform.Rotate(Vector3.up * actions.ContinuousActions[1] * rotationSpeed);


        // Jumping is basically a dicreate action but here is made a continuous
        if (Mathf.RoundToInt(actions.DiscreteActions[0]) == 1 && playerIsGrounded)
        {
            // Make the jump
            movementDirection.y = jumpSpeed;
        }
        // And apply the gravity
        movementDirection.y -= gravity * Time.deltaTime;
        // Finally apply it too to the character controller
        characterController.Move(movementDirection * Time.deltaTime);
        rewardAgent();
        if (hasAnimation)
        {
            changeAnimationState(actions);
        }
        
      
    }


    public void rewardAgent()
    {
        float distanceFromTarget = Vector3.Distance(transform.localPosition, targetTransform.localPosition);
        // Check if the agent fell off platform
        if (transform.localPosition.y < 0)
        {
            // Change the position of the agent to a random one.
            transform.localPosition = new Vector3(Random.Range(-floorRadius + 1.0f, floorRadius - 1.0f), floorHeight + 0.5f, Random.Range(-floorRadius + 1.0f, floorRadius - 1.0f));
            SetReward(-10f);
            EndEpisode();
        }
        else
        {
            float normalization = 0.0001f; 
            float reward = -normalization * distanceFromTarget; // -0.001 * distance for every step.
            AddReward(reward);
        }
    }

    /*
     *  When the Behavior Type is set to Heuristic Only in the Behavior Parameters of the Agent, 
     *  the Agent will use the Heuristic() method to generate the actions of the Agent. As such, 
     *  the Heuristic() method writes to the array of floats provided to the Heuristic method as argument. 
     *  Note: Do not create a new float array of action in the Heuristic() method, 
     *  as this will prevent writing floats to the original action array.
     */
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        ActionSegment<int> discreateActions = actionsOut.DiscreteActions;

        continuousActions[0] = Input.GetAxisRaw("Vertical");
        continuousActions[1] = Input.GetAxisRaw("Horizontal");
        discreateActions[0] = Input.GetButton("Jump") ? 1 : 0;

        // Debug.Log("CA0: " + continuousActions[0]);
        // Debug.Log("CA1: " + continuousActions[1]);
        // Debug.Log("DA0: " + discreateActions[0]);

    }
    void changeAnimationState(ActionBuffers actions)
    {
        if (actions.ContinuousActions[0] == 1)
        {
            movedForward = true;
            movedBackwards = false;
        }
        else if (actions.ContinuousActions[0] == -1)
        {
            movedForward = false;
            movedBackwards = true;
        }
        else
        {
            movedForward = false;
            movedBackwards = false;
        }

    }
    void applyAnimations()
    {
        if (hasAnimation)
        {
            bool isRunning = animator.GetBool("IsRunning");
            bool isRunningBackwards = animator.GetBool("IsRunningBackwards");
            bool isOnAir = animator.GetBool("IsOnAir");
            // Idle to Standing Jump
            if ( !playerIsGrounded && !isRunning && !isRunningBackwards && !movedForward && !movedBackwards)
            {
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsRunningBackwards", false);
                animator.SetBool("IsOnAir", true);
            }
            // Running to Running Jump 
            else if (isRunning && !playerIsGrounded && movedForward)
            {
                animator.SetBool("IsRunning", true);
                animator.SetBool("IsRunningBackwards", false);
                animator.SetBool("IsOnAir", true);
            }
            // Idle to Running Forward
            else if (isRunning && movedForward)
            {
                animator.SetBool("IsRunning", true);
                animator.SetBool("IsRunningBackwards", false);
                animator.SetBool("IsOnAir", false);
            }
            // Running to keep Running
            else if (!isRunning && movedForward)
            {
                animator.SetBool("IsRunning", true);
                animator.SetBool("IsRunningBackwards", false);
                animator.SetBool("IsOnAir", false);
            }
            // Idle to Start Running Backwards
            else if( !isRunningBackwards && movedBackwards)
            {
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsRunningBackwards", true);
                animator.SetBool("IsOnAir", false);
            }
            // Idle
            else if ((isRunning && !movedForward) || (isRunningBackwards && !movedBackwards))
            {
                animator.SetBool("IsRunning", false);
                animator.SetBool("IsRunningBackwards", false);
                animator.SetBool("IsOnAir", false);
            }
        }

    }
    void Update()
    {
        applyAnimations();
    }
}
   






