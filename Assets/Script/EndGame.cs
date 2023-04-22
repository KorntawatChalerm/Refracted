using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    bool interactable;
     public Dialogue dialogue;
    public string result;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable)
        {
            if(GameManager.instance.diaryCount < 7)
            {
                result = "badend";

            }
            else
            {
                result = "goodend";

            }
            StartCoroutine(EndingGame(result));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Debug.Log("true");
            interactable = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))

        {
            Debug.Log("false");
            interactable = false;

        }
    }
    IEnumerator EndingGame(string result)
    {
        DialogueManager.instance.StartDialogue(dialogue);

        yield return new WaitForSeconds(1);
        SceneManage.instance.ChangeScene(result);
    }
}
