using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EventManager : IEventManager
{
    private static EventManager instance;

    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventManager();
            }

            return instance;
        }
    }

    private List<IApplicationEvent> _applicationEvents;

    public EventManager()
    {
        _applicationEvents = new List<IApplicationEvent>();
        Init();
    }
    
    public T GetEvent<T>()
    {
        return (T)_applicationEvents.FirstOrDefault(x => x.GetType() == typeof(T));
    }

    public void Invoke<T>()
    {
        ((IApplicationEvent) GetEvent<T>()).Invoke();
    }

    public void InvokeInt<T>(int value)
    {
        ((IApplicationEvent) GetEvent<T>()).InvokeInt(value);
    }

    public void InvokeString<T>(string value)
    {
        ((IApplicationEvent) GetEvent<T>()).InvokeString(value);
    }

    public void InvokeDoubleString<T>(string value1, string value2)
    {
        ((IApplicationEvent)GetEvent<T>()).InvokeDoubleString(value1, value2);
    }

    public void InvokeFloat<T>(float value)
    {
        ((IApplicationEvent) GetEvent<T>()).InvokeFloat(value);
    }

    public void InvokeBool<T>(bool value)
    {
        ((IApplicationEvent) GetEvent<T>()).InvokeBool(value);
    }

    public void InvokeDoubleBool<T>(bool value1, bool value2)
    {
        ((IApplicationEvent) GetEvent<T>()).InvokeDoubleBool(value1,value2);
    }

    public void InvokeObject<T>(object value)
    {
        ((IApplicationEvent) GetEvent<T>()).InvokeObject(value);
    }
    
    private void Init()
    {
        _applicationEvents.AddRange(new List<IApplicationEvent>
        {
            
        });
    }
}
