using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IWordsViewSpawner
{
	WordView GenerateWordView();
	void DeactivateWordView();
}
