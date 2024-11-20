using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : Items
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
        if (gameObject.activeSelf == false && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gamer Bro's house") && trigger.gameObject.tag == "Dialogue" && flipped == 0)
        {
            trigger.gameObject.SetActive(!gameObject.activeSelf);
            flipped = 1;
        }
    }
}
