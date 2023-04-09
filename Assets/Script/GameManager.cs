using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
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
    public Volume chaseVolume;
    public GameObject enemy;
    public GameObject player;
    public float maxChaseVolume;
    [SerializeField]
    private float distanceThreshold = 5f;
    private float distanceRatio = 0f;


    private bool isPause;
    private bool isMainmenu = false;
    private int currentMap;
    [Header("Bool checker")]
    public bool isdead;
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

        if (enemy == null)
        {
            // Enemy object not found, set distance ratio to 0
            distanceRatio = 0f;
        }
        else
        {
            //enemy = GameObject.FindWithTag("Enemy");

            player = GameObject.FindWithTag("Player");

            float distance = Vector3.Distance(player.transform.position, enemy.transform.position);

            distanceRatio = Mathf.Clamp01((distanceThreshold - distance) / distanceThreshold);
        }
        

        chaseVolume.weight = distanceRatio;

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
        Time.timeScale = 1f;
                pauseUI.SetActive(false);
        isPause = false;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        isPause = true;
                pauseUI.SetActive(true);
    }

    private void OnEnable()
    {
        // Register the FindEnemyInScene method to the SceneManager.sceneLoaded event
        SceneManager.sceneLoaded += FindEnemyInScene;
    }

    private void OnDisable()
    {
        // Unregister the FindEnemyInScene method from the SceneManager.sceneLoaded event
        SceneManager.sceneLoaded -= FindEnemyInScene;
    }

    private void FindEnemyInScene(Scene scene, LoadSceneMode mode)
    {
        // Find the enemy in the scene with the specified tag
        enemy = GameObject.FindWithTag("Enemy")?.gameObject;
    }

}
