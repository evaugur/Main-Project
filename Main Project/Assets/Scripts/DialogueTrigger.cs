using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;
    public static DialogueTrigger instance;

    void Start()
    {
        if (instance == null || instance.gameObject.tag == "Starting Dialogue" && gameObject.tag == "After Dialogue")
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Got from https://www.youtube.com/watch?v=_nRzoTzeyxU

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
