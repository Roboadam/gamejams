using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject floor;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Mesh floorMesh = floor.GetComponent<Mesh>();
        int index = Random.Range(0, floorMesh.vertices.Length - 1);
        agent.destination = floorMesh.vertices[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
