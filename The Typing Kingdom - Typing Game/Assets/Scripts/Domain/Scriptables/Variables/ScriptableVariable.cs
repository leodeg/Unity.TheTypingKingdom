using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableVariable<T> : ScriptableObject
{
    public T value;

    public UnityEvent OnSetValue;

    public void Set(T value)
    {
        this.value = value;
        OnSetValue?.Invoke();
    }
}
