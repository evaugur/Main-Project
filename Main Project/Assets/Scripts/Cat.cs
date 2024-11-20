using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cat : Items
{
    public static Items instance;

    private int flipped = 0;

    [SerializeField] private GameObject startingDialogue;
    [SerializeField] private GameObject afterDialogue;
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
        if (gameObject.activeSelf == false && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Old Lady's house") && trigger.gameObject.tag == "Dialogue" && flipped == 0)
        {
            trigger.gameObject.SetActive(!gameObject.activeSelf);
            flipped = 1;
        }
    }
}
