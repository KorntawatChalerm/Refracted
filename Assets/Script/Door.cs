using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Door : MonoBehaviour
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
            SceneManage.instance.ChangeScene(id);
            Map.instance.MapUpdate(id);
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
