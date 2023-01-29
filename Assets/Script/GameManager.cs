using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static public GameManager instance;
    public GameObject pauseUI;
    public GameObject deadUI;
    public GameObject map;
    public GameObject diary;
    public int diaryCount;


    private bool isPause;
    private bool isMainmenu = false;
    private int currentMap;
    public bool isdead;

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
            isPause = true;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                Resume();
            }
            else
            {
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
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }
    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }



}
