using System;
using UnityEngine.Events;

public class DropdownQWERTYSectionType : Dropdown<QWERTYSectionType>
{
	public UnityEventQWERTYSectionType OnIndexChanged;

	public override void IndexChanged()
	{
		base.IndexChanged();
		OnIndexChanged?.Invoke(CurrentValue);
	}
}


