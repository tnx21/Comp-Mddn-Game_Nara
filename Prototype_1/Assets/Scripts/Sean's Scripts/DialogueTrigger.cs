using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// when added to an object, this is where the sentences and speakers are created. 
// used to send dialogues to the dialogueManager
public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue;   // collection of speaker name and their sentences

    public bool isFinalDialogue;    // used to determine this as the last dialogue of the game, before the dialogueManager redirects to end cutscene

    // when placed on an object that is used as a trigger, this will trigger the dialogue to be played
    private void OnTriggerEnter(Collider other)
    {
        TriggerDialogue(); 
    }

    // send dialogue to manager to be displayed
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, isFinalDialogue);
    }
}
