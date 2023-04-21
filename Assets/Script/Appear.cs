using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public GameObject target;
    public int requiredProgress;
    public bool ifMore;
    public bool ifLess;
    public float waitTime;

    void Update()
    {
        if (ifMore)
        {
            if (GameManager.instance.progress >= requiredProgress)
            {
                StartCoroutine(StartAppear());
            }
        }
        else if (ifLess)
        {
            if (GameManager.instance.progress <= requiredProgress)
            {
                StartCoroutine(StartAppear());

            }
        }

    }

    IEnumerator StartAppear()
    {
        yield return new WaitForSeconds(waitTime);
        target.SetActive(true);
        StopCoroutine(StartAppear());

    }
}
