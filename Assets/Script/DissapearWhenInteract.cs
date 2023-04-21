using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearWhenInteract : MonoBehaviour
{
    public GameObject targetdestroy;
    public Fade targetFade;

    bool interactable;
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable)
        {
            StartCoroutine(StartDissappear());
            targetFade.trigger = true;
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
    IEnumerator StartDissappear()
    {
        yield return new WaitForSeconds(1);
        Destroy(targetdestroy);
    }
}
