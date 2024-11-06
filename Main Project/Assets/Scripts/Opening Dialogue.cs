using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDialogue : MonoBehaviour
{
    public Dialogue dialogue;

    public void Start()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
