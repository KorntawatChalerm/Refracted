using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity;

public class SceneManage : MonoBehaviour
{
    public static SceneManage instance;
    public GameObject settingUI;
    //public GameObject settingUI;
     Animator anim;
    public int currentScene;
    void Start()
    {
       anim = GetComponent<Animator>();
    }
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
    }
    void Update()
    {

    }
    public void  NewGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.DeleteAll();
    }
    public void BacktoMainmenu()
    {
        
        currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentScene);
        PlayerPrefs.SetInt("Diary", GameManager.instance.diaryCount);
        PlayerPrefs.SetInt("Progress", GameManager.instance.progress);
        SceneManager.LoadScene("MainMenu");
        GameManager.instance.isMainmenu = true;
        Time.timeScale = 1f;
    }
    public void Continue()
    {
        int scene = PlayerPrefs.GetInt("SavedScene");
        int diary = PlayerPrefs.GetInt("Diary");
        int progress = PlayerPrefs.GetInt("Progress");
        SceneManager.LoadScene(scene);
        GameManager.instance.diaryCount = diary;
        GameManager.instance.progress = progress;
    }

    public void Setting()
    {
        if(settingUI.activeSelf)
        settingUI.SetActive(false);
        else
            settingUI.SetActive(true);

    }

    public void ChangeScene(string mapname)
    {
        Debug.Log("changingScene");
        Fade();
        StartCoroutine(StartChangeScene(mapname));
    }
   IEnumerator StartChangeScene(string mapname)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(mapname);
    }
    public void Fade()
    {
        anim.Play("FadeOut", 0, 0f);

    }

    public void Exit()
    {
        Application.Quit();
    }

    
}
