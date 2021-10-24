using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CubeCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float stageArea = 81.0f*81.0f;
        float areaLeft = 100.0f * 100.0f - stageArea;
        float maxWallHeight = 8.0f;
        float wallheightOffset = 1.0f;
        int wallCounter = 0;
        // create #numberOfWalls walls
        for (int i=-162; i<=162; i+=3)
        {
           for (int j=-162; j<=162; j += 3)
            {

            

                if(i>=-42 && i<=42 && j>=-42 && j <=42)
                {
                    continue;
                }
                // Add to the counter
                wallCounter += 1;
                // Create a new gameObject
                GameObject wallObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
                // Name it
                wallObject.name = ("DecorationWall_" + wallCounter);
                //wallObject.AddComponent<BoxCollider>();
                wallObject.transform.localScale = new Vector3(3.0f, (float)(UnityEngine.Random.value * maxWallHeight + wallheightOffset + 0.1 * (Math.Abs(3 ^ i) + Math.Abs(3 ^ j))), 3.0f);
                //Makes the GameObject new Parent.
                wallObject.transform.parent = this.transform;
                // Get the wall's Mesh Size
                Vector3 wallMeshSize = wallObject.GetComponent<MeshFilter>().mesh.bounds.size;
                // Get the wall's Local Scale
                Vector3 wallLocalScale = wallObject.transform.localScale;
                // Calculate the wallHeight and get the half of it in order to determine the exact height of the spawn
                float wallHeight = wallMeshSize.y * wallLocalScale.y / 2.0f;
                // Calculate the wall's radius in order to not collide with the outer walls
                float wallRadiusX = wallMeshSize.x * wallLocalScale.x / 2.0f;
                float wallRadiusZ = wallMeshSize.z * wallLocalScale.z / 2.0f;
                // Position the wall to a random one.
                wallObject.transform.localPosition = new Vector3(i, 0, j);
                // Set Material 0
                MeshRenderer wallMeshRenderer = wallObject.GetComponent<MeshRenderer>();
                // and it's color..
                wallMeshRenderer.materials[0].color = Color.white;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
