using System;
using UnityEngine.Events;

public class DropdownGameLanguage : Dropdown<GameLanguage>
{
	public UnityEventGameLanguage OnIndexChanged;

	public override void IndexChanged()
	{
		base.IndexChanged();
		OnIndexChanged?.Invoke(CurrentValue);
	}
}