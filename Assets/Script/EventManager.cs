using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    public event Action TestEvent;
    public event Action<int> TestInteraction;
    public event Action<int> chaseEvent;
    public event Action<int> questEvent;



    //event manager will act as a middle man  
    // receive trigger from something then activated all event within that triggered event
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

    public void StartTestEvent()
    {
        TestEvent?.Invoke();
    }

    public void StartInteraction(int id)
    {
        TestInteraction?.Invoke(id);
    }
   
    public void StartChase(int id)
    {
        chaseEvent?.Invoke(id);
    }

    public void ProgressUp(int id)
    {
        questEvent?.Invoke(id);
    }
}
