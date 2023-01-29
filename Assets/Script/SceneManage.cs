using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public static SceneManage instance;
    public GameObject settingUI;
    public int currentScene;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    void BacktoMainmenu()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentScene);
        PlayerPrefs.SetInt("Diary", GameManager.instance.diaryCount);
        SceneManager.LoadScene("MainMenu");

    }
    void Continue()
    {
        int scene = PlayerPrefs.GetInt("SavedScene");
        int diary = PlayerPrefs.GetInt("Diary");
        SceneManager.LoadScene(scene);
        GameManager.instance.diaryCount = diary;
    }

    void Setting()
    {
        settingUI.SetActive(true);

    }

}
