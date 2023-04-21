using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyItem : MonoBehaviour
{
    public Image item;
    public Sprite itemImage;
    public Sprite blank;
    public GameObject bubble;
    public int itemID;
    bool interactable;
    void Start()
    {
        GameObject Item = GameObject.Find("Item");
        item = Item.GetComponent<Image>();
        EventManager.instance.questEvent += IncreaseProgress;
        EventManager.instance.questEvent += StartShowImage;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable)
        {
            EventManager.instance.ProgressUp(itemID);

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

    void IncreaseProgress(int id)
    {
        if (id == itemID)
            GameManager.instance.progress++;
    }
    void StartShowImage(int id)
    {
        if (id == itemID)
            StartCoroutine(ShowImage());
    }
    IEnumerator ShowImage()
    {

        item.sprite = itemImage;
        yield return new WaitForSeconds(0.1f);
        item.sprite = blank;

        Destroy(gameObject);
    }
    private void OnDisable()
    {
        EventManager.instance.questEvent -= IncreaseProgress;
        EventManager.instance.questEvent -= StartShowImage;

    }
}
