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
    private Vector3 startPos;
    private Vector3 facing = Vector3.forward;

    // Start is called before the first frame update
    void Start()
    {
        PauseGame();
        rigidbody = GetComponent<Rigidbody>();
        startPos = this.transform.position;
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            ResumeGame();
        }

        if(Input.GetKey(KeyCode.Q))
        {
            Application.Quit();
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
        this.pause = true;
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        foreach(Ghost ghost in ghosts)
        {
            Destroy(ghost.gameObject);
        }

        ghosts = new List<Ghost>();

        this.pause = false;
        Time.timeScale = 1;
        this.transform.position = startPos;
        introText.SetActive(false);
        winText.SetActive(false);
        gameOverText.SetActive(false);
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

        if(movement != Vector3.zero)
        {
            facing = movement;
        }

        this.transform.rotation = Quaternion.LookRotation(facing, Vector3.up);

        vel = movement.normalized * 2;
        rigidbody.velocity = vel;
    }
}
