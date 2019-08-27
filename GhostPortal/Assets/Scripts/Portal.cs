using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject ghostPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time % 10 == 0)
        {
            GameObject ghostGameObject = Instantiate(ghostPrefab, new Vector3(6.82f, 0.84f, 4.82f), Quaternion.identity);
            ghostGameObject.GetComponent<Ghost>().GhostIndex = 1;
        }
    }
}
