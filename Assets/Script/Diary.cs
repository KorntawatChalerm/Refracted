using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoBehaviour
{

    public GameObject bubble;
    public Image diary;
    public Sprite diarypage;
    bool interactable;
    public int diaryNumber;
    void Start()
    {
        if(GameManager.instance.diaryCount == diaryNumber)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (GameManager.instance.diaryCount == diaryNumber)
        {
            gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E)&& interactable)
        {
            GameManager.instance.diaryCount++;
            GameManager.instance.diary.SetActive(true);
            diary.sprite = diarypage;
            Time.timeScale = 0f;

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
            //Debug.Log("false");
            interactable = false;

            bubble.SetActive(false);
        }
    }
}
