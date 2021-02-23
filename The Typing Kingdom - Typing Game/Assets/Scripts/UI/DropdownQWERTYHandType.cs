using System;
using UnityEngine.Events;

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




