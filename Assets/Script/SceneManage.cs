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
    }
    public void BacktoMainmenu()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentScene);
        PlayerPrefs.SetInt("Diary", GameManager.instance.diaryCount);
        SceneManager.LoadScene("MainMenu");

    }
    public void Continue()
    {
        int scene = PlayerPrefs.GetInt("SavedScene");
        int diary = PlayerPrefs.GetInt("Diary");
        SceneManager.LoadScene(scene);
        GameManager.instance.diaryCount = diary;
    }

    public void Setting()
    {
        if(settingUI.activeSelf)
        settingUI.SetActive(false);
        else
            settingUI.SetActive(true);

    }

    public void ChangeScene(int index)
    {
        Debug.Log("changingScene");
        anim.Play("FadeOut",0,0f);
        StartCoroutine(StartChangeScene(index));
    }
   IEnumerator StartChangeScene(int index)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(index);
    }

   public void Exit()
    {
        Application.Quit();
    }

    
}
