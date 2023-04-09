using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTrigger : MonoBehaviour
{
    public int correctID;
    public GameObject enemy;
    void Start()
    {
        EventManager.instance.chaseEvent += Spawn;
    }

    void Spawn(int id)
    {
        //spawn enemy
        if (id == correctID)
        {
            enemy.SetActive(true);
        }

    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EventManager.instance.StartChase(correctID);
        }

    }


}
 