using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueScreen;
    public GameObject obstacles;
    
    private void Start()
    {
        // init a new Queue for the sentences
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        dialogueScreen.SetActive(true);
        
        // clears previous sentences
        sentences.Clear();

        foreach (var sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        var sentence = sentences.Dequeue();
        // Stops the coroutine if the Player moves to forward to quickly
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // types every letter frame by frame
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.04f);
        }
    }

    private void EndDialogue()
    {
        Debug.Log("End of conversation");
        dialogueScreen.SetActive(false);
        obstacles.SetActive(true);
        
    }
}
