using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public GameObject continueButton;
    public GameObject player;
    private Queue<string> sentences;
    
    
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        
        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        continueButton.SetActive(false);

        if (sentences.Count == 0)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;  // slows down text animation speed
            yield return null; 
            yield return null;
            yield return null;
            yield return null; 
            yield return null;
            yield return null;
        }
        continueButton.SetActive(true);
    }
    
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
 
}
