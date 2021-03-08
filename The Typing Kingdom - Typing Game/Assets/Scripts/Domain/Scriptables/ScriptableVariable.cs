using System;
using UnityEngine;
using UnityEngine.Events;

public class ScriptableVariable<T> : ScriptableObject
{
	public T variable;

	public UnityEvent OnSetVariable;
	public Action<T> OnSetVariableReturnVariable;

	public void Set(T variable)
	{
		this.variable = variable;

		OnSetVariable?.Invoke();
		OnSetVariableReturnVariable?.Invoke(variable);
	}
}
