using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : MonoBehaviour
{
    bool fall = false;
    public Transform point;
    public float fallspeed;
    public int fallID;
    public int fadeID;
    public bool progress;
    void Start()
    {
        EventManager.instance.TestInteraction += Falldown;
        EventManager.instance.TestInteraction += Fade;
    }

    void Falldown(int id)
    {
        if (id == fallID)
        fall = true;
    }
    void Update()
    {
        if (fall)
        {
            transform.position = Vector3.MoveTowards(transform.position, point.position, fallspeed * Time.deltaTime);
        }
    }

    void ProgressUp()
    {
        GameManager.instance.ProgressUp();
    }
    void Fade(int id)
    {
        if (id == fadeID)
        {
            SceneManage.instance.Fade();
            ProgressUp();
        }
    }
    private void OnDisable()
    {
        EventManager.instance.TestInteraction -= Falldown;
        EventManager.instance.TestInteraction -= Fade;

    }
}
