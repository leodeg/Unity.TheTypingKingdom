using System;
using UnityEngine.Events;

public class DropdownQWERTYHandType : Dropdown<QWERTYHandType>
{
	public UnityEventQWERTYHandType OnIndexChanged;

	public override void IndexChanged()
	{
		base.IndexChanged();
		OnIndexChanged?.Invoke(CurrentValue);
	}
}




