using System;
using System.Linq;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dropdown<T> : MonoBehaviour, IDropdown where T : Enum
{
	[SerializeField]
	private TMP_Dropdown dropdown;

	public T CurrentValue { get; set; }

	private void Awake()
	{
		PopulateOptions();
	}

	public virtual void IndexChanged()
	{
		CurrentValue = (T)Enum.Parse(typeof(T), dropdown.options[dropdown.value].text);
		Debug.Log($"{this.name}: changed current value to {CurrentValue.ToString()}");
	}

	public virtual void SetDefaultIndex(string enumText)
	{
		int index = 0;
		foreach (var item in dropdown.options)
		{
			if (item.text == enumText)
				break;
			++index;
		}

		dropdown.value = index;
	}

	public void AddOption(string text)
	{
		dropdown.options.Add(new TMP_Dropdown.OptionData { text = text });
	}

	public void PopulateOptions()
	{
		ClearOptions();

		string[] valuesNames = Enum.GetNames(typeof(T));
		dropdown.AddOptions(valuesNames.ToList());
	}

	public void ClearOptions()
	{
		dropdown.options.Clear();
	}
}

