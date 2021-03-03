using System;
using UnityEngine.Events;

[Serializable]
public class UnityEventGameLanguage : UnityEvent<GameLanguage> { }

public class DropdownGameLanguage : Dropdown<GameLanguage>
{
	public UnityEventGameLanguage OnIndexChanged;

	public override void IndexChanged()
	{
		base.IndexChanged();
		OnIndexChanged?.Invoke(CurrentValue);
	}
}