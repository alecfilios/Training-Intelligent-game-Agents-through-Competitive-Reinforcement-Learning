using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        transform.hasChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool("IsRunning");
        bool movedForward = Input.GetKey("w");//transform.hasChanged;
        if (!isRunning && movedForward)
        {
            animator.SetBool("IsRunning", true);
            print("Kyle is Running.");
        }
        if (isRunning && !movedForward)
        {
            animator.SetBool("IsRunning", false);
            print("Kyle Stopped.");           
        }

        transform.hasChanged = false;
    }
}
