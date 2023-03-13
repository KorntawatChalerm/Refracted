using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Door : MonoBehaviour
{
    public GameObject bubble;
    public GameObject player;
    bool interactable;
    public int mapid;
    public int doorid;

    void Start()
    {
        if (PlayerPrefs.GetInt("doorID") == doorid)
        {
            Debug.Log("door " + doorid);
            player = GameObject.Find("Player");
            player.transform.position = gameObject.transform.position;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable)
        {
            GameManager.instance.isChasing=false;
            PlayerPrefs.SetInt("doorID", doorid);
            Map.instance.MapUpdate(mapid);
            SceneManage.instance.ChangeScene(mapid);
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
