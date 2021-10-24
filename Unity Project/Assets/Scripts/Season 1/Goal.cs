using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    /*
    * Public
    */
   
    [SerializeField] private HumanoidAgent redAgent;
    [SerializeField] private HumanoidAgent blueAgent;
    [SerializeField] private GameObject floor;
    /*
     * Private
     */
    private Vector3 floorMeshSize;
    private Vector3 floorLocalScale;
    private float floorRadius;
    private Vector3 goalMeshSize;
    private Vector3 goalLocalScale;
    private Vector3 goalActualScale;

    // Start is called before the first frame update
    void Start()
    {
        floorMeshSize = floor.GetComponent<MeshFilter>().mesh.bounds.size;
        floorLocalScale = floor.transform.localScale;
        floorRadius = floorMeshSize.x * floorLocalScale.x / 2.0f;

        goalMeshSize = gameObject.GetComponent<MeshFilter>().mesh.bounds.size;
        goalLocalScale = gameObject.transform.localScale;
        goalActualScale = new Vector3(goalMeshSize.x * goalLocalScale.x, goalMeshSize.y * goalLocalScale.y, goalMeshSize.z * goalLocalScale.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        float minBorder = -floorRadius + (goalActualScale.x / 2.0f);
        float maxBorder =  floorRadius - (goalActualScale.x / 2.0f);
        // Change the position of the goal to a random one.
        transform.localPosition = new Vector3(Random.Range(minBorder, maxBorder), 0.5f + goalActualScale.y/2.0f , Random.Range(minBorder, maxBorder));
        // Check who reached the goal
        if (other.tag == "redAgentTag")
        {
            // Give the reward and the penalty respectively 
            redAgent.SetReward(10f);
            blueAgent.SetReward(-10f);
            // End the episode for both of them
            redAgent.EndEpisode();
            blueAgent.EndEpisode();
            // Change the color of the goal to show the current winner
            //GetComponent<Renderer>().material.SetColor("_Color", Color.red);//redAgent.transform.Find("AgentCubeWithCamera").GetComponent<Renderer>().material;

        }
        else if (other.tag == "blueAgentTag")
         {
            // Give the reward and the penalty respectively 
            blueAgent.SetReward(10f);
            redAgent.SetReward(-10f);
            // End the episode for both of them
            blueAgent.EndEpisode();
            redAgent.EndEpisode();
            // Change the color of the goal to show the current winner
            //GetComponent<Renderer>().material.SetColor("_Color", Color.blue);// = blueAgent.transform.Find("AgentCubeWithCamera").GetComponent<Renderer>().material;

        }
    }

}