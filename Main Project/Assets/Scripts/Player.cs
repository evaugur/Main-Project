using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Player : MonoBehaviour
{

    [SerializeField] float runSpeed = 5f;
    public static Rigidbody2D rb;
    private bool dialogueHasPlayer = false;
    private bool itemHasPlayer = false;
    private GameObject item;

    private Scene scene;

    private List<IPickupable> inventory = new List<IPickupable>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (dialogueHasPlayer && Input.GetKeyDown(KeyCode.E))
        {
            DialogueTrigger.instance.TriggerDialogue();
        }
        if(itemHasPlayer && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(inventory.IndexOf(item.gameObject.GetComponent<IPickupable>()));
            inventory.Add(item.gameObject.GetComponent<IPickupable>());
            Debug.Log(inventory.IndexOf(item.gameObject.GetComponent<IPickupable>()));
            item.gameObject.GetComponent<IPickupable>().Pickup();
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
            dialogueHasPlayer = true;
        }
        if(trigger.gameObject.tag == "Item")
        {
            itemHasPlayer = true;
            item = trigger.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Dialogue")
        {
            dialogueHasPlayer = false;
        }
        if (trigger.gameObject.tag == "Item")
        {
            itemHasPlayer = false;
        }
    }

}
