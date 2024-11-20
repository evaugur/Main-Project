using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class Items : MonoBehaviour, IPickupable
{
    public static Items instance;

    private bool itemHasPlayer = false;

    private int flipped = 0;

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
    public void Update()
    {
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
