using System;
using UnityEngine;

public class BaseEvent : IApplicationEvent
{
    public Action simpleEvent;
    public Action<bool> boolEvent;
    public Action<bool, bool> doubleBoolEvent;
    public Action<double> doubleEvent;
    public Action<bool, string> boolStringEvent;
    public Action<float, float> doubleFloatEvent;
    private Action<int, int> doubleIntEvent;
    private Action<string, string> doubleStringEvent;
    private Action<float> floatEvent;
    private Action<GameObject> gameObjectEvent;
    private Action<int> intEvent;
    private Action<object> objectEvent;
    private Action<string> stringEvent;
    private Action<float, float, float> tripleFloatEvent;
    private Action<GameObject, GameObject> twoGameObjectEvent;

    public void Invoke()
    {
        simpleEvent?.Invoke();
    }

    public void InvokeBool(bool value)
    {
        boolEvent?.Invoke(value);
    }

    public void InvokeBoolString(bool value1, string value2)
    {
        boolStringEvent?.Invoke(value1, value2);
    }

    public void InvokeDouble(double value)
    {
        doubleEvent?.Invoke(value);
    }

    public void InvokeDoubleBool(bool value1, bool value2)
    {
        doubleBoolEvent?.Invoke(value1, value2);
    }

    public void InvokeDoubleFloat(float value1, float value2)
    {
        doubleFloatEvent?.Invoke(value1, value2);
    }

    public void InvokeDoubleInt(int value1, int value2)
    {
        doubleIntEvent?.Invoke(value1, value2);
    }

    public void InvokeDoubleString(string value1, string value2)
    {
        doubleStringEvent?.Invoke(value1, value2);
    }

    public void InvokeFloat(float value)
    {
        floatEvent?.Invoke(value);
    }

    public void InvokeGameObject(GameObject value)
    {
        gameObjectEvent?.Invoke(value);
    }

    public void InvokeInt(int value)
    {
        intEvent?.Invoke(value);
    }

    public void InvokeObject(object value)
    {
        objectEvent?.Invoke(value);
    }

    public void InvokeString(string value)
    {
        stringEvent?.Invoke(value);
    }

    public void InvokeTripleFloat(float value1, float value2, float value3)
    {
        tripleFloatEvent?.Invoke(value1, value2, value3);
    }

    public void InvokeTwoGameObject(GameObject value1, GameObject value2)
    {
        twoGameObjectEvent?.Invoke(value1, value2);
    }
}