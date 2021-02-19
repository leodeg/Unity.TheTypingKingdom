using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpawnManager))]
[RequireComponent(typeof(InputManager))]
public class GameInitializer : MonoBehaviour
{
	[Header("Game Objects")]

	[SerializeField]
	private Transform target;

	[Header("Managers")]

	[SerializeField]
	private SpawnManager spawnManager;

	[SerializeField]
	private WordsViewSpawner wordsViewGenerator;

	[SerializeField]
	private InputManager inputManager;

	[Header("Assets")]

	[SerializeField]
	public TextAsset qwertyKeyboardJsonEn;

	[SerializeField]
	public TextAsset qwertyKeyboardJsonRu;

	[SerializeField]
	public TextAsset wordsArrayJsonEn;

	[SerializeField]
	public TextAsset wordsArrayJsonRu;

	[Header("Words Spawning Properties")]

	[SerializeField]
	private int minWordLength = 4;

	[SerializeField]
	private int maxWordLength = 8;

	private void Awake()
	{
		target = GameObject.FindGameObjectWithTag(Tags.Player).transform;

		var wordsController = new WordsController();

		inputManager = GetComponent<InputManager>();
		inputManager.WordsController = wordsController;

		wordsViewGenerator = GetComponent<WordsViewSpawner>();
		spawnManager.WordViewGenerator = wordsViewGenerator;
		spawnManager.WordsController = wordsController;
		spawnManager.Target = target;

		// Fake word generator
		//spawnController.TextGenerator = new FakeTextGenerator();

		// QWERTY word generator
		//var keyboardQWERTY = JsonHelper.ReadFromAsset<KeyboardQWERTY>(qwertyKeyboardJsonEn.text);
		//spawnManager.TextGenerator = new QWERTYTextGenerator(keyboardQWERTY, new QWERTYOptions(), minWordLength, maxWordLength);

		// Words generator
		spawnManager.TextGenerator = new WordSandboxTextGenerator(JsonHelper.ReadFromAsset<string[]>(wordsArrayJsonRu.text));

	}

	private void Start()
	{

	}
}
