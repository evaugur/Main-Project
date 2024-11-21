using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class Items : MonoBehaviour, IPickupable
{
    private bool itemHasPlayer = false;

    public void Pickup()
    {
        Debug.Log("Pickup called");
        Inventory.inventory.Add(this.gameObject.GetComponent<IPickupable>());
        gameObject.SetActive(false);
    }

    public void Update()
    {
        if (itemHasPlayer && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Got input");
            this.gameObject.GetComponent<IPickupable>().Pickup();
        }
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Player")
        {
            Debug.Log("Entered trigger");
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
