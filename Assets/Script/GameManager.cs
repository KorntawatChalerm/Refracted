using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{

    static public GameManager instance;
    public GameObject pauseUI;
    public GameObject deadUI;
    public GameObject map;
    public GameObject diary; //diary ui
    public int diaryCount;
    public int progress;

    [Header("Volume")]
    [SerializeField]
    private Volume normalVolume;
    [SerializeField]
    private Volume mirrorVolume;
    public GameObject chaseVolume;

    private bool isPause;
    private bool isMainmenu = false;
    private int currentMap;
    [Header("Bool checker")]
    public bool isdead;
    public bool isChasing;
    public bool isDiary;
    public bool normalWorld;
    public bool mirrorWorld1;

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

    private void Update()
    {
        if (isMainmenu)
        {
            return;
        }

        if (isdead)
        {
            deadUI.SetActive(true);
            Time.timeScale = 0f;
            return;
        }

        if (normalWorld)
        {
            normalVolume.weight = 1f;
        }
        else if (mirrorWorld1)
        {
            normalVolume.weight = 0f;
            mirrorVolume.weight = 1f;
        }
        else
        {
            mirrorVolume.weight = 0f;
        }

        if (isChasing)
        {
            chaseVolume.SetActive(true);
        }
        else
        {
            chaseVolume.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                pauseUI.SetActive(false);

                Resume();
            }
            else
            {
                pauseUI.SetActive(true);

                Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (map.activeSelf)
            {
                Debug.Log("map close");
                Time.timeScale = 1f;
                map.SetActive(false);
            }
            else
            {

                Debug.Log("map open");
                Time.timeScale = 0f;
                map.SetActive(true);
            }

        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (diary.activeSelf)
            {
                Debug.Log("diary close");
                Time.timeScale = 1f;
                diary.SetActive(false);
            }
            else
            {

                Debug.Log("diary open");
                Time.timeScale = 0f;
                diary.SetActive(true);
            }

        }




    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isPause = false;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        isPause = true;
    }



}
