using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueSwitch : MonoBehaviour
{
    public static GameObject start;
    public static GameObject after;

    public static int momDialogue;

    public static int businessGameOver = 0;
    public static int oldGameOver = 0;
    public static int gamerGameOver = 0;

    // Start is called before the first frame update
    void Awake()
    {
        start = GameObject.FindWithTag("Starting Dialogue");
        after = GameObject.FindWithTag("After Dialogue");
        after.SetActive(false);
    }

    void Update()
    {
        if (businessGameOver >= 1 && oldGameOver >= 1 && gamerGameOver >= 1)
        {
            Player.InitiateGameover();
        }
    }

    public static void SwitchDialogue()
    {
        start.SetActive(false);
        after.SetActive(true);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Business Dad's house"))
        {
            businessGameOver++;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Old Lady's house"))
        {
            oldGameOver++;
        }
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gamer Bro's house"))
        {
            gamerGameOver++;
        }
    }

    public static void MoveOn()
    {
        momDialogue++;
    }
}
