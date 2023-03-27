using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject bubble;
    bool interactable;
    public int id;
    
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable)
        {
            Debug.Log("weee");
            EventManager.instance.StartInteraction(id);

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
