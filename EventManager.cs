using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    private static EventManager instance_;
    public static EventManager Instance 
    {
        get
        {
            return instance_;
        }
    }

    [Tooltip("Prefab of the UI for all events")]
    public GameObject EventTemplate;

    [Tooltip("An array of events to randomly choose from when generating events.")]
    public UnexpectedEvent[] Events;

    public UnexpectedEvent CurrentEvent;

    private void Awake()
    {
        UnexpectedEvent.EventBox = EventTemplate;
        instance_ = this;
    }

    private void Start()
    {
        StartSpecificEvent(Events.Length - 1);
    }

    public void StartRandomEvent()
    {
        if(CurrentEvent != null)
        {
            CurrentEvent.DeconstructEvent();
            CurrentEvent = null;
        }
        if(CurrentEvent == null)
        {
            int val = Random.Range(0, Events.Length);

             Events[val].ConstructEvent(transform);
            CurrentEvent = Events[val];
        }
        
    }

    public void StartSpecificEvent(int i)
    {
        Events[i].ConstructEvent(this.transform);
        CurrentEvent = Events[i];
    }

}
