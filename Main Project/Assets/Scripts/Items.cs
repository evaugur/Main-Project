using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Items : MonoBehaviour, IPickupable
{

    private bool itemHasPlayer = false;
    public static Items instance;
    [SerializeField] private int specificTrigger;
    private int oldLady = 1;
    private int businessDad = 2;
    private int gameBro = 3;

    // Set the trigger as active only if the dialogue has happened for that specific item

    public void Pickup()
    {
        Inventory.inventory.Add(this.gameObject.GetComponent<IPickupable>());
        gameObject.SetActive(false);
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (specificTrigger == businessDad || specificTrigger ==  oldLady || specificTrigger == gameBro)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (itemHasPlayer && Input.GetKeyDown(KeyCode.E))
        {
            this.gameObject.GetComponent<IPickupable>().Pickup();
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            itemHasPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            itemHasPlayer = false;
        }
    }
}
