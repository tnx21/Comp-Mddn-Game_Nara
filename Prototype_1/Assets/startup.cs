using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startup : MonoBehaviour {

    public Dialogue[] dialogues;

    public void Start()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue[0]);
        if (this.dialogues.Length > 0) {
            FindObjectOfType<DialogueManager>().QueueDialogue(this.dialogues);
        }
        
    }
}
