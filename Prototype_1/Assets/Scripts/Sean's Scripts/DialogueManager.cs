﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// This is used to store and display text in the dialog box within the game
public class DialogueManager : MonoBehaviour
{

    bool isFinalDialogue;   // for determining that the game is over and needs to end the scene

    public Animator animator;   // moves the dialogue
    public Text nameText;   // speaker name
    public Text dialogueText;   // speakers dialogue

    private Queue<string> sentences;    // sentences in dialogue
    private Queue<Dialogue> dialogueQueue;  // queue of dialogue for cutscenes (so names can change)

    bool isCutscene = false;    // to determine if we take from the queue or not

    // initialize queues
    void Start()
    {
        sentences = new Queue<string>();
        dialogueQueue = new Queue<Dialogue>();
    }

    // moves dialogue box to be displayed and displays the speakers name on it 
    // and puts each sentence of the given dialogue into the sentences queue.
    public void StartDialogue(Dialogue dialogue, bool isFinalDialogue)
    {
        this.isFinalDialogue = isFinalDialogue; // for determining that the game is over and needs to end the scene

        animator.SetBool("IsOpen", true);   // moves dialogue box onto canvas so that it can be seen
        Debug.Log("Starting Conversation: ");
        nameText.text = dialogue.name;  // put name into displayed dialogue box
        sentences.Clear();  // resets the dialogue box, ready for new sentences

        // queue up the sentences from dialogue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplaynextSentence();  // call method that displays sentences
    }

    // makes a queue of dialogues for use of multiple dialogues and speakers
    public void QueueDialogue(Dialogue[] dialogues)
    {
        isCutscene = true;  // set to true because this queue is cutscene specific at the moment
        // make sure the dialogues passed in is not empty
        if (dialogues.Length == 0)
        {
            return;
        }
        // add dialogues to dialogues queue
        foreach (Dialogue dialogue in dialogues)
        {
            dialogueQueue.Enqueue(dialogue);
        }
        StartDialogue(this.dialogueQueue.Dequeue(), isFinalDialogue);   // start the first dialogue after queue is made
    }

    // displays each sentence, closes dialogue box if nothing left
    public void DisplaynextSentence()
    {
        // no sentences left, close dialogue box
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();  // pull out new sentence to be displayed
        dialogueText.text = sentence;   // display next sentence
        Debug.Log(sentence);

        EventSystem.current.SetSelectedGameObject(null);    // deselects the button in dialogue box after being pressed (before it would stay highlighted)
    }

    // ends dialogue and hides display in game
    void EndDialogue()
    {
        Debug.Log("End of conversation");
        animator.SetBool("IsOpen", false);  // hide dialogue box from view while not in use
        // check if we are pulling from dialogues queue or not
        if (isCutscene)
        {
            // something left in queue, pull it out
            if (dialogueQueue.Count != 0)
            {
                StartDialogue(dialogueQueue.Dequeue(), isFinalDialogue);
            }
            else
            {
                isCutscene = false; // cutscene finished, stop from checking queue
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   // transition from cutscene to next scene
            }
        }
        else if (isFinalDialogue)
        {
            StartCoroutine(ReturnToMenu()); // game over, call method to take us back to main menu
        }
    }
    
    // returns the scene back to the main menu
    private IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(2); // delay before scene change
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2); // navigate back to menu
    }
}
