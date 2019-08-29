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
        new Vector3(0.13f, 1.54f, 9.29f),
        new Vector3(-8.77f, 1.54f, 7.87f),
        new Vector3(2.02f, 1.54f, 1.05f)
    };

    public void Stop()
    {
        agent.isStopped = true;
    }

    public void Resume()
    {
        agent.isStopped = false;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = intermediateStarts[GhostIndex % intermediateStarts.Length];
        player.GetComponent<Player>().ghosts.Add(this);
        Debug.Log("Destination " + agent.destination);
    }

    void Update()
    {
        Debug.Log("distance = " + agent.remainingDistance + ":" + reachedIntermediatePoint + " destination:" + agent.destination + " position:" + transform.position);
        if(!reachedIntermediatePoint && agent.remainingDistance < 0.5f)
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
