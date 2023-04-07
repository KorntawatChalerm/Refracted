using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public static Map instance;
    public Image mapImage;
    public Sprite[] maps;
    void Start()
    {
        
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
    // Update is called once per frame
    void Update()
    {
        
    }

    public void MapUpdate(string mapname)
    {
        for (int i = 0; i < maps.Length; i++)
        {
            if (maps[i].name == mapname)
            {
                mapImage.sprite = maps[i];
            }
        }
    }
}
