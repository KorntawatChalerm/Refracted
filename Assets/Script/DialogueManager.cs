using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public GameObject dialogueUI;
    public TMP_Text text;
    public Image leftSprite;
    public Image rightSprite;

    private Queue<string> sentences;
    private Queue<Sprite> sprite1list;
    private Queue<Sprite> sprite2list;
    private bool isTalking;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        sentences = new Queue<string>();
        sprite1list = new Queue<Sprite>();
        sprite2list = new Queue<Sprite>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("dialogue started");
        isTalking = true;
        Time.timeScale = 0;
        dialogueUI.SetActive(true);


        sentences.Clear();
        sprite1list.Clear();
        sprite2list.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (Sprite image in dialogue.sprite1)
        {
            sprite1list.Enqueue(image);
        }
        foreach (Sprite image in dialogue.sprite2)
        {
            sprite2list.Enqueue(image);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Sprite sprite1 = sprite1list.Dequeue();
        Sprite sprite2 = sprite2list.Dequeue();
        Debug.Log(sentence);
     //   text.text = (sentence);
        leftSprite.sprite = (sprite1);
        rightSprite.sprite = (sprite2);
        StopAllCoroutines();
        StartCoroutine(TypingSentence(sentence));
    }
    IEnumerator TypingSentence(string sentence)
    {
        text.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            text.text += letter;

            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
    private void Update()
    {
        if (!isTalking)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            DisplayNextSentence();
        }
    }
    void EndDialogue()
    {
        Time.timeScale = 1;
        isTalking = false;
        Debug.Log("End conver");
        dialogueUI.SetActive(false);

    }
}
