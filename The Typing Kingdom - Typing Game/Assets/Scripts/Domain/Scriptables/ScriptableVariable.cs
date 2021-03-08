using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableVariable<T> : ScriptableObject
{
    public T variable;

    public UnityEvent OnSetVariable;

    public void Set(T variable)
    {
        this.variable = variable;
        OnSetVariable?.Invoke();
    }
}
