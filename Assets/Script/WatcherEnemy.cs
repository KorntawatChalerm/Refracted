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

    public float blinkDelay;
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
            yield return new WaitForSeconds(blinkDelay);
            blinking = true;
            yield return new WaitForSeconds(blinkDelay);

        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (blinking)
        {
            alertCurrent = 0f;
            return;
        }

        if (collision.CompareTag("Player") && !Input.GetKey(KeyCode.LeftControl))
        {
            alertCurrent += alertFill*Time.deltaTime;
            if(alertCurrent >= alertMax)
            {
                GameManager.instance.isdead = true;
            }
        }
    }
}
