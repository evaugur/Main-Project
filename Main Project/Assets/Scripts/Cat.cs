using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Items
{
    public static Items instance;

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

    void Update()
    {
        if (gameObject.activeSelf == false)
        {
            startingDialogue.SetActive(false);
            afterDialogue.SetActive(true);
        }
    }
}
