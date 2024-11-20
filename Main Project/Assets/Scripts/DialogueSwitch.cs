using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSwitch : MonoBehaviour
{
    public static GameObject start;
    public static GameObject after;

    // Start is called before the first frame update
    void Awake()
    {
        start = GameObject.FindWithTag("Starting Dialogue");
        after = GameObject.FindWithTag("After Dialogue");
        after.SetActive(false);
    }

    public static void SwitchDialogue()
    {
        start.SetActive(false);
        after.SetActive(true);
    }
}
