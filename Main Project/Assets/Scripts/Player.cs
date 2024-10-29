using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Player : MonoBehaviour
{

    [SerializeField] float runSpeed = 5f;
    private Rigidbody2D rb;

    private Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = moveInput * runSpeed;
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Old Lady")
        {
            Debug.Log("This runs!");
            SceneManager.LoadScene("Old Lady's house");
            sceneSpawner = 1;
            Debug.Log(sceneSpawner);
        }
        if (trigger.gameObject.tag == "Kid")
        {
            SceneManager.LoadScene("Kid's house");
            sceneSpawner = 2;
        }
        if (trigger.gameObject.tag == "Business Dad")
        {
            SceneManager.LoadScene("Business Dad's house");
            sceneSpawner = 3;
        }
        if (trigger.gameObject.tag == "Gamer")
        {
            SceneManager.LoadScene("Gamer Bro's house");
            sceneSpawner = 4;
        }
        if (trigger.gameObject.tag == "Neighborhood")
        {
            SceneManager.LoadScene("Neighborhood");
        }
        if (trigger.gameObject.tag == "Spawner")
        {
            if (sceneSpawner == 1)
            {
                Debug.Log("This runs!");
                transform.position = new Vector3(2.99f, -3.93f, 0f);
            }
            if (sceneSpawner == 2)
            {
                transform.position = new Vector3(15.02f, -3.93f, 0f);
            }
            if (sceneSpawner == 3)
            {
                transform.position = new Vector3(-6.02f, -3.93f, 0f);
            }
            if (sceneSpawner == 4)
            {
                transform.position = new Vector3(9f, -3.93f, 0f);
            }
        }
        
    }

}
