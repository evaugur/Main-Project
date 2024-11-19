using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Items
{
    public static Items instance;

    private int flipped = 0;

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

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (gameObject.activeSelf == false && trigger.gameObject.GetComponent<DialogueTrigger>().characterName == "Old Lady" && flipped == 0)
        {
            trigger.gameObject.SetActive(!gameObject.activeSelf);
            flipped = 1;
        }
    }
}
