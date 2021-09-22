using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiTalk : MonoBehaviour
{
    public GameManager gm;
    public int triggerScore = 3;
    public Dialogue dialogue;

    public void ShowDialogue()
    {
        if (gm.GetPlayerScore() == triggerScore)
        {
            // Freezes Time
            Time.timeScale = 0;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            // Let time flow again
            Time.timeScale = 1;
        }
    }
}
