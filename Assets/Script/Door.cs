using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Door : MonoBehaviour
{
    public Dialogue dialogue;
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
            Camera camera = FindObjectOfType<Camera>();
            Vector3 campos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10f);
            camera.transform.position = campos;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable)
        {
            if (GameManager.instance.progress == PlayerPrefs.GetInt("Progress"))
            {
                GameManager.instance.isChasing = false;
                PlayerPrefs.SetInt("doorID", doorid);
                Map.instance.MapUpdate(mapid);
                SceneManage.instance.ChangeScene(mapid);
            }
            else
            {
                DialogueManager.instance.StartDialogue(dialogue);

            }
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
