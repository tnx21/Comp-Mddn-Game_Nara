using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;
    private Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        Debug.Log("Starting Conversation: ");

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplaynextSentence();
    }

    public void QueueDialogue(Dialogue[] dialogues)
    {
        if (dialogues.Length == 0)
        {
            return;
        }
        foreach (Dialogue dialogue in dialogues)
        {
            dialogueQueue.Enqueue(dialogue);
        }
        StartDialogue(this.dialogueQueue.Dequeue());
    }

    public void DisplaynextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        Debug.Log(sentence);
        EventSystem.current.SetSelectedGameObject(null);
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
        animator.SetBool("IsOpen", false);
        if (dialogueQueue.Count != 0)
        {
            StartDialogue(dialogueQueue.Dequeue());
        }
    }
}
