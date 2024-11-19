using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Items : MonoBehaviour, IPickupable
{

    private bool itemHasPlayer = false;

    public void Pickup()
    {
        Inventory.inventory.Add(this.gameObject.GetComponent<IPickupable>());
        gameObject.SetActive(false);
    }

    void Awake()
    {
    }
    void Update()
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
