using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public int requiredProgress;
    public bool ifMore;
    public bool ifLess;
    public float waitTime;
    void Start()
    {

    }

    void Update()
    {
        if (ifMore)
        {
            if (GameManager.instance.progress >= requiredProgress)
            {
                StartCoroutine(StartDisappear());
            }
        }
        else if (ifLess)
        {
            if (GameManager.instance.progress <= requiredProgress)
            {
                StartCoroutine(StartDisappear());

            }
        }
       
    }

    IEnumerator StartDisappear()
    {
      yield   return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
        StopCoroutine(StartDisappear());

    }
}
