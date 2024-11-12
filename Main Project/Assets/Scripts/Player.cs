using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Player : MonoBehaviour
{

    [SerializeField] float runSpeed = 5f;
    public static Rigidbody2D rb;
    private bool hasPlayer = false;

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
        if (hasPlayer && Input.GetKeyDown(KeyCode.E))
        {
            DialogueTrigger.instance.TriggerDialogue();
        }
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
            SceneManager.LoadScene("Old Lady's house");
            Spawner.sceneSpawner = 1;
        }
        if (trigger.gameObject.tag == "Kid")
        {
            SceneManager.LoadScene("Kid's house");
            Spawner.sceneSpawner = 2;
        }
        if (trigger.gameObject.tag == "Business Dad")
        {
            SceneManager.LoadScene("Business Dad's house");
            Spawner.sceneSpawner = 3;
        }
        if (trigger.gameObject.tag == "Gamer")
        {
            SceneManager.LoadScene("Gamer Bro's house");
            Spawner.sceneSpawner = 4;
        }
        if (trigger.gameObject.tag == "Neighborhood")
        {
            SceneManager.LoadScene("Neighborhood");
        }
        if (trigger.gameObject.tag == "Spawner")
        {
            if (Spawner.sceneSpawner == 1)
            {
                transform.position = new Vector3(2.99f, -3.93f, 0f);
            }
            if (Spawner.sceneSpawner == 2)
            {
                transform.position = new Vector3(15.02f, -3.93f, 0f);
            }
            if (Spawner.sceneSpawner == 3)
            {
                transform.position = new Vector3(-6.02f, -3.93f, 0f);
            }
            if (Spawner.sceneSpawner == 4)
            {
                transform.position = new Vector3(9f, -3.93f, 0f);
            }
        }
        if (trigger.gameObject.tag == "Dialogue")
        {
            hasPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Dialogue")
        {
            hasPlayer = false;
        }
    }

}
