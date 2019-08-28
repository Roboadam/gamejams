using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject ghostPrefab;
    public GameObject player;
    private int numGhosts = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > numGhosts * 10)
        {
            Debug.Log("Creating ghost " + numGhosts);
            GameObject ghostGameObject = Instantiate(ghostPrefab, new Vector3(6.82f, 0.84f, 4.82f), Quaternion.identity);
            ghostGameObject.GetComponent<Ghost>().GhostIndex = numGhosts;
            ghostGameObject.GetComponent<Ghost>().player = player;
            numGhosts++;
        }
    }
}
