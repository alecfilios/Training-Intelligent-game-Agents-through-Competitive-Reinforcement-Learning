using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    [SerializeField]
    private GameObject floor;
    [SerializeField]
    private float numberOfWalls;
    [SerializeField]
    private float maxWallSize;
    [SerializeField]
    private float wallSizeOffset;



    // Start is called before the first frame update
    void Start()
    {
        createRandomWalls();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void createRandomWalls()
    {
        // Get some floor info to Init the new positions
        Vector3 floorMeshSize = floor.GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 floorLocalScale = floor.transform.localScale;
        float floorRadius = floorMeshSize.x * floorLocalScale.x / 2.0f;
        float floorHeight = floorMeshSize.y * floorLocalScale.y / 2.0f;

        // create #numberOfWalls walls
        for (int i = 0; i < numberOfWalls; i++)
        {
            // Create a new gameObject
            GameObject wallObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // Name it
            wallObject.name = ("Wall_" + i);
            // Tag it
            wallObject.tag = "wall";
            // Add a Box Collider
            wallObject.AddComponent<BoxCollider>();
            wallObject.transform.localScale = new Vector3(Random.value * maxWallSize + wallSizeOffset, Random.value * maxWallSize + wallSizeOffset, Random.value * maxWallSize + wallSizeOffset);
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
            wallObject.transform.localPosition = new Vector3(Random.Range(-floorRadius + wallRadiusX, floorRadius - wallRadiusX), floorHeight + wallHeight, Random.Range(-floorRadius + wallRadiusZ, floorRadius - wallRadiusZ));
            // Set Material 0
            MeshRenderer wallMeshRenderer = wallObject.GetComponent<MeshRenderer>();
            // and it's color..
            wallMeshRenderer.materials[0].color = Color.gray;
            // is Trigger
            wallObject.GetComponent<Collider>().isTrigger = true;
        }
    }
}
