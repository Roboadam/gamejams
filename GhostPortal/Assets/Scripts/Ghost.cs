using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool reachedIntermediatePoint = false;
    public GameObject player;

    public int GhostIndex { get; set; } = 0;

    private static Vector3[] intermediateStarts = new Vector3[] {
        new Vector3(-0.96f, 1.54f, 13.04f),
        new Vector3(-11.14f, 1.54f, 8.06f),
        new Vector3(4.32f, 1.54f, 0.23f)
    };

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = intermediateStarts[GhostIndex % intermediateStarts.Length];
        Debug.Log("Destination " + agent.destination);
    }

    // Update is called once per frame
    void Update()
    {
        if(!reachedIntermediatePoint && agent.remainingDistance < 0.01f)
        {
            reachedIntermediatePoint = true;
            Debug.Log("Reached intermediate point");
        }

        if(reachedIntermediatePoint)
        {
            agent.destination = player.transform.position;
        }
    }
}
