using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startup : MonoBehaviour
{
	[SerializeField]
	private WordSpawnController spawnController;

	[SerializeField]
	private InputController inputController;

	private void Awake()
	{
		var wordsController = new WordsController();
		spawnController.TextGenerator = new FakeTextGenerator();
		spawnController.WordController = wordsController;
		inputController.WordController = wordsController;
	}
}
