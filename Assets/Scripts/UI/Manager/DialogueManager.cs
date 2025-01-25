using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private GameUIManager gameUIManager;
    public Animator animator;

    private string currentSentence;

    public bool isTyping = false;

    void Awake()
    {
        gameUIManager = GetComponent<GameUIManager>();
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        Debug.Log("Starting convertation with " + dialogue.author);
        sentences.Clear();

        gameUIManager.author.text = dialogue.author;
        foreach (string sentence in dialogue.sentences)
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


        if (isTyping)
        {
            gameUIManager.sentence.text = currentSentence;
            isTyping = false;
            StopAllCoroutines();
            return;
        }

        string sentence = sentences.Dequeue();
        currentSentence = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        isTyping = true;
        gameUIManager.sentence.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            gameUIManager.sentence.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        isTyping = false;
    }
    public void EndDialogue()
    {
        gameUIManager.OnEndDialog();
        animator.SetBool("IsOpen", false);
    }
}
