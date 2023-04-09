using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool byCollider;

    void Start()
    {
        if (GameManager.instance.progress != PlayerPrefs.GetInt("Progress"))
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && byCollider)
            TriggerDialogue();
        Destroy(gameObject);
    }
    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);

    }
}
