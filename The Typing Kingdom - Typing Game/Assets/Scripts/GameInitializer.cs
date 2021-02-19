using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpawnManager))]
[RequireComponent(typeof(InputManager))]
public class GameInitializer : MonoBehaviour
{
	[SerializeField]
	private SpawnManager spawnController;

	[SerializeField]
	private WordsViewSpawner wordsViewGenerator;

	[SerializeField]
	private InputManager inputController;

	[SerializeField]
	private KeyboardQWERTYScriptable keyboard;

	[SerializeField]
	public TextAsset jsonFile;

	[SerializeField]
	private Transform target;

	[SerializeField]
	private int minWordLength = 4;

	[SerializeField]
	private int maxWordLength = 8;

	private void Awake()
	{
		target = GameObject.FindGameObjectWithTag(Tags.Player).transform;

		var wordsController = new WordsController();

		inputController = GetComponent<InputManager>();
		inputController.WordsController = wordsController;

		wordsViewGenerator = GetComponent<WordsViewSpawner>();
		//spawnController.TextGenerator = new FakeTextGenerator();
		spawnController.WordViewGenerator = wordsViewGenerator;
		spawnController.WordsController = wordsController;
		spawnController.Target = target;

		var keyboardQWERTY = JsonHelper.ReadFromAsset<KeyboardQWERTY>(jsonFile.text);
		spawnController.TextGenerator = new QWERTYTextGenerator(keyboardQWERTY, new QWERTYOptions(), minWordLength, maxWordLength);
	}

	private void Start()
	{

	}
}
