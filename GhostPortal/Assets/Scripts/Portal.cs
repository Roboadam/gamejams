using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject ghostPrefab;
    public GameObject player;
    private int numGhosts = 1;
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!pause && Time.time > numGhosts * 4)
        {
            Debug.Log("Creating ghost " + numGhosts);
            GameObject ghostGameObject = Instantiate(ghostPrefab, new Vector3(0.66f, 0.84f, 13.7f), Quaternion.identity);
            ghostGameObject.GetComponent<Ghost>().GhostIndex = numGhosts;
            ghostGameObject.GetComponent<Ghost>().player = player;
            numGhosts++;
        }
    }
}
