using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedKeyItem : MonoBehaviour
{
    public Dialogue dialogue;
    public Sprite diarypage;
    public Image diary;
    public GameObject bubble;
    bool interactable;
    public int id;
    public string whatItemNeed;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable&& PlayerPrefs.GetString(whatItemNeed) == "true")
        {
            Debug.Log("key used");
            GameManager.instance.diaryCount++;
            GameManager.instance.diary.SetActive(true);
            diary.sprite = diarypage;
            Time.timeScale = 0f;
            Destroy(gameObject);
        }
        else
        {
            DialogueManager.instance.StartDialogue(dialogue);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Debug.Log("true");
            interactable = true;
            bubble.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))

        {
            Debug.Log("false");
            interactable = false;

            bubble.SetActive(false);
        }
    }
}
