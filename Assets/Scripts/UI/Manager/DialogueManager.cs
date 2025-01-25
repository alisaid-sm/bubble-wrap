using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private UIManager uIManager;
    public Animator animator;

    void Awake()
    {
        uIManager = GetComponent<UIManager>();
        Debug.Log(uIManager);
    }
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialog(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        Debug.Log("Starting convertation with " + dialogue.author);
        sentences.Clear();

        uIManager.author.text = dialogue.author;
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

        string sentence = sentences.Dequeue();
        // uIManager.sentence.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        uIManager.sentence.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            uIManager.sentence.text += letter;
            yield return new WaitForSeconds(0.05f);

        }
    }
    private void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
