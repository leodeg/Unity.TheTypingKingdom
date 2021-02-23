using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class UnityEventQWERTYSectionType : UnityEvent<QWERTYSectionType> { }

public class DropdownQWERTYSectionType : Dropdown<QWERTYSectionType>
{
	public UnityEventQWERTYSectionType OnIndexChanged;

	public override void IndexChanged()
	{
		base.IndexChanged();
		OnIndexChanged?.Invoke(CurrentValue);
	}
}


