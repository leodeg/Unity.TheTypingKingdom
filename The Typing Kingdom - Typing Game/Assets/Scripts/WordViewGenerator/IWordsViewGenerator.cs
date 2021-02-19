using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IWordsViewGenerator
{
	WordView GenerateView();
	void DeactivateWordView();
}
