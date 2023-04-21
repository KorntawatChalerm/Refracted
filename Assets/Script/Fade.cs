using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public bool fadein;
    public bool fadeout;
    public int requiredProgress;
    public bool trigger;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {

        if (GameManager.instance.progress >= requiredProgress)
        {
            trigger = true;
        }
        
        if (trigger)
        {
            if (fadein)
            {
                anim.Play("FadeInItem", 0, 0f);
                fadein = false;
            }
            if (fadeout)
            {

                anim.Play("FadeOutItem", 0, 0f);
                fadeout = false;
            }

        }

    }
}
