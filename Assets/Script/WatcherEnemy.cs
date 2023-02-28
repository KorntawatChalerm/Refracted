using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherEnemy : MonoBehaviour
{
    [SerializeField]
    private bool blinking;
    [SerializeField]
    private float alertMax;
    [SerializeField]
    private float alertCurrent;
    [SerializeField]
    private float alertFill;
    void Start()
    {
        StartCoroutine(Blinking());
    }

    void Update()
    {

    }
    IEnumerator Blinking()
    {

        while (true)
        {
            blinking = false;
            yield return new WaitForSeconds(2f);
            blinking = true;
            yield return new WaitForSeconds(2f);

        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (blinking)
        {
            alertCurrent = 0f;
            return;
        }

        if (collision.CompareTag("Player"))
        {
            alertCurrent += alertFill*Time.deltaTime;
            if(alertCurrent >= alertMax)
            {
                GameManager.instance.isdead = true;
            }
        }
    }
}
