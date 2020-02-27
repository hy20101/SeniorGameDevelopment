using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();                    //create queue for display sentences
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string CurrentSentence in dialogue.sentences)
        {
            sentences.Enqueue(CurrentSentence);             //queue all sentences
        }

        PrintNextSentences();
    }

    public void PrintNextSentences()
    {
        if (sentences.Count == 0)                           //end of queue, stop printing
        {
            EndSentences();
            return;
        }
        else
        {
            string CurrentSentence = sentences.Dequeue();

            //dialogueText.text = CurrentSentence;          //display sentence text normally

            StopAllCoroutines();                            //stop other coroutines before start next coroutines
            StartCoroutine(TypeText(CurrentSentence));      //start next coroutines
        }

        IEnumerator TypeText(string CurrentSentence)        //print 1 letter at a time
        {
            dialogueText.text = "";
            foreach (char text in CurrentSentence.ToCharArray())
            {
                dialogueText.text += text;
                yield return null;
            }
        }
    }

    public void EndSentences()                              // in case of no queue
    {
        print("End of sentences");
    }
}
