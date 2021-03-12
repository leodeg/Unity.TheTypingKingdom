using System;
using UnityEngine.Events;

public class DropdownGameDifficulty : Dropdown<GameDifficulty>
{
	public UnityEventGameDifficulty OnIndexChanged;

	public override void IndexChanged()
	{
		base.IndexChanged();
		OnIndexChanged?.Invoke(CurrentValue);
	}
}


