using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class UnityEventGameDifficulty : UnityEvent<GameDifficulty> { }

public class DropdownGameDifficulty : Dropdown<GameDifficulty>
{
	public UnityEventGameDifficulty OnIndexChanged;

	public override void IndexChanged()
	{
		base.IndexChanged();
		OnIndexChanged?.Invoke(CurrentValue);
	}
}


