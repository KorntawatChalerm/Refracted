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
    public bool isTalking;
    private bool isTyping;
    [SerializeField]
    private float typeSpeed = 0.05f;
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
        Time.timeScale = 0;
        Debug.Log("dialogue started");
        isTalking = true;
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
        typeSpeed = 0.05f;
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }


        string sentence = sentences.Dequeue();
        Sprite sprite1 = sprite1list.Dequeue();
        Sprite sprite2 = sprite2list.Dequeue();
        Debug.Log(sentence);
        leftSprite.sprite = (sprite1);
        rightSprite.sprite = (sprite2);


        StopAllCoroutines();
        StartCoroutine(TypingSentence(sentence));
    }
    IEnumerator TypingSentence(string sentence)
    {
        text.text = "";
        isTyping = true;
        foreach (char letter in sentence.ToCharArray())
        {
            text.text += letter;

            yield return new WaitForSecondsRealtime(typeSpeed);
        }
        isTyping = false;
    }
    private void Update()
    {
        if (!isTalking)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0) && isTyping)
        {
            typeSpeed = 0f;

        }
        else if (Input.GetMouseButtonDown(0) && !isTyping)
        {
            DisplayNextSentence();
        }
    }
    void EndDialogue()
    {
        isTalking = false;
        Debug.Log("End conver");
        dialogueUI.SetActive(false);
        Time.timeScale = 1;

    }
}
