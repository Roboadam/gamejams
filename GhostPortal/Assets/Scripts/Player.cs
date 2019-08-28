using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 vel = Vector3.zero;
    public GameObject gameOverText;
    public GameObject winText;
    public GameObject portal;
    public GameObject introText;
    public List<Ghost> ghosts = new List<Ghost>();
    private bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        PauseGame();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            introText.SetActive(false);
            ResumeGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision with " + collision.gameObject.tag);
        if(collision.gameObject.tag == "Ghost")
        {
            PauseGame();
            gameOverText.SetActive(true);
        }
        else if(collision.gameObject.tag == "Portal")
        {
            PauseGame();
            winText.SetActive(true);
        }
    }

    private void PauseGame()
    {
        foreach(Ghost ghost in ghosts)
        {
            ghost.Stop();
        }

        portal.GetComponent<Portal>().pause = true;
        this.pause = true;
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        portal.GetComponent<Portal>().pause = false;
        this.pause = false;
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        if(this.pause)
        {
            return;
        }

        Vector3 movement = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;
        }
        if(Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
        }
        if(Input.GetKey(KeyCode.S))
        {
            movement += Vector3.back;
        }
        if(Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }

        vel = movement.normalized * 2;
        rigidbody.velocity = vel;
    }
}
