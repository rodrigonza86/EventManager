using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataEvent : UnityEvent<EventData> { }

public class EventManager : MonoBehaviour
{
    private Dictionary<string, DataEvent> events;
    private static EventManager eventManager;
    private static EventManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType<EventManager>();

                if (!eventManager)
                {
                    Debug.LogError("No EventManager in the scene!");
                }
                else
                {
                    eventManager.Init();
                }
            }

            return eventManager;
        }
    }

    private void Init()
    {
        if (events == null)
        {
            events = new Dictionary<string, DataEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction<EventData> listener)
    {
        DataEvent e = null;

        if (instance.events.TryGetValue(eventName, out e))
        {
            e.AddListener(listener);
        }
        else
        {
            e = new DataEvent();
            e.AddListener(listener);

            instance.events.Add(eventName, e);
        }
    }

    public static void StopListening(string eventName, UnityAction<EventData> listener)
    {
        DataEvent e = null;

        if (eventManager == null)
            return;

        if (instance.events.TryGetValue(eventName, out e))
        {
            e.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(EventData data)
    {
        DataEvent e = null;

        if (instance.events.TryGetValue(data.name, out e))
        {
            e.Invoke(data);
        }
    }

    private void OnDestroy()
    {
        if (eventManager == null)
            return;

        foreach (var e in instance.events.Values)
        {
            e.RemoveAllListeners();
        }
    }
}
