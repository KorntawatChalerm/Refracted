using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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
    public Volume watcherVolume;
    public float alertRatio;


    private Animator animator;
    private string currentAnimaton;

    void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(Blinking());
    }

    void Update()
    {
        alertRatio = Mathf.Clamp01((alertCurrent) / alertMax);
        watcherVolume.weight = alertRatio;

    }
    IEnumerator Blinking()
    {

        while (true)
        {
            blinking = true;
            ChangeAnimationState("close");

            yield return new WaitForSeconds(blinkDelay);
            blinking = false;

            ChangeAnimationState("open");

            yield return new WaitForSeconds(blinkDelay);

        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (blinking && alertCurrent >= 0)
        {
            alertCurrent -= alertFill * 3 * Time.deltaTime;
            return;
        }

        if (collision.CompareTag("Player") && !Input.GetKey(KeyCode.LeftControl))
        {
            alertCurrent += alertFill * Time.deltaTime;
            if (alertCurrent >= alertMax)
            {
                GameManager.instance.isdead = true;
            }
        }
    }

    void ChangeAnimationState(string newAnimation)
    {
       if (currentAnimaton == newAnimation) return;
        Debug.Log("blink");
        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        alertCurrent = 0f;
    }
}
