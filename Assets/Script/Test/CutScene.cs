using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public Queue<Dialogue> dialogueQueue;
    public Dialogue[] dialogues;

    private void Start()
    {
        dialogueQueue = new Queue<Dialogue>();
        foreach (Dialogue dialogue in dialogues)
        {
            dialogueQueue.Enqueue(dialogue);
        }

    }
    public void PlayDialogue()
    {
        Dialogue next = dialogueQueue.Dequeue();
        DialogueManager.instance.StartDialogue(next);

    }


}
