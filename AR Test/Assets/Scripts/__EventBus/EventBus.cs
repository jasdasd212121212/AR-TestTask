using System;
using System.Collections.Generic;
using UnityEngine;

public class EventBus
{
    private Dictionary<string, List<object>> _events = new Dictionary<string, List<object>>();

    public void Subscribe<T>(Action<T> action)
    {
        string key = typeof(T).Name;

        if (_events.ContainsKey(key))
        {
            _events[key].Add(action);
        }
        else
        {
            _events.Add(key, new List<object>() { action });
        }
    }

    public void Unsubscribe<T>(Action<T> action)
    {
        string key = typeof(T).Name;

        if (_events.ContainsKey(key))
        {
            _events[key].Remove(action);
        }
        else
        {
            Debug.LogError($"Critical error -> can`t usubscribe from not subscribed event: {key}");
        }
    }

    public void Invoke<T>(T mark)
    {
        string key = typeof(T).Name;

        if (_events.ContainsKey(key))
        {
            foreach (Action<T> action in _events[key])
            {
                action?.Invoke(mark);
            }
        }
        else
        {
            Debug.LogWarning($"Trying to invoke null event: {key}");
        }
    }
}