using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Items
{
    private Cat instance;
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
