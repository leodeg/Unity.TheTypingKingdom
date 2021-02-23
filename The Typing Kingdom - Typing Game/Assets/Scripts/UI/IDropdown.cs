using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public interface IDropdown
{
	void IndexChanged();
	void AddOption(string text);
	void PopulateOptions();
	void ClearOptions();
}

