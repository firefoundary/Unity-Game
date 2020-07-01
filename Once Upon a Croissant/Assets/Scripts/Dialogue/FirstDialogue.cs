using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDialogue : MonoBehaviour
{
    public Dialogue dialogue;
    public bool freezePlayer;
    public bool boss;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, freezePlayer, boss);
    }

}