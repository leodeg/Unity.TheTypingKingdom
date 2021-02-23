using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class UnityEventQWERTYHandType : UnityEvent<QWERTYHandType> { }

public class DropdownQWERTYHandType : Dropdown<QWERTYHandType>
{
	public UnityEventQWERTYHandType OnIndexChanged;

	public override void IndexChanged()
	{
		base.IndexChanged();
		OnIndexChanged?.Invoke(CurrentValue);
	}
}




