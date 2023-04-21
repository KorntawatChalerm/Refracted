using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject bubble;
    public bool byCollider;
    public bool fade;
    public bool quest;
    public int requiredProgress;
    bool interactable;

    void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.instance.progress != requiredProgress)
        {
            return;
        }
       
    }
    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
        if (quest)
        {
            GameManager.instance.ProgressUp();

        }
        if (fade)
        {
            Fade();
        }
        Debug.Log("dialogue trigger");
    }

    void Update()
    {
        if (GameManager.instance.progress != requiredProgress)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && interactable)
        {
            if (GameManager.instance.progress == requiredProgress)
            {
                TriggerDialogue();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GameManager.instance.progress != requiredProgress)
        {
            return;
        }
        if (collision.CompareTag("Player") && !byCollider)
        {
            // Debug.Log("true");
            interactable = true;
            bubble.SetActive(true);
        }
        if (collision.CompareTag("Player") && byCollider && GameManager.instance.progress == requiredProgress)
        {
            TriggerDialogue();
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameManager.instance.progress != requiredProgress)
        {
            return;
        }
        if (collision.CompareTag("Player") && !byCollider)

        {
            Debug.Log("false");
            interactable = false;

            bubble.SetActive(false);
        }
    }
    public void Fade()
    {
        SceneManage.instance.Fade();

    }
}
