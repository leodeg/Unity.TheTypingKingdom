using System;
using UnityEngine.Events;

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


