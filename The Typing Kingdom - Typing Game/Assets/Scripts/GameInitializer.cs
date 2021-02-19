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

	[Header("Game Settings")]

	[SerializeField]
	private GameSettingsScritable gameSettings;

	[SerializeField]
	private PlayerStatsScriptable playerStats;

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


	// Local use fields
	private TextAsset currentDictionaryJson;
	private ITextGenerator currentTextGenerator;


	private void Awake()
	{
		currentTextGenerator = GetTextGenerator();

		if (currentTextGenerator == null)
		{
			Debug.LogError("Cannot create text generator!");
			return;
		}

		AssignComponents();
		AssignCompomnentsReferences();
	}

	private void AssignComponents()
	{
		if (target == null)
			target = GameObject.FindGameObjectWithTag(Tags.Player).transform;

		if (inputManager == null)
			inputManager = GetComponent<InputManager>();

		if (spawnManager == null)
			spawnManager = GetComponent<SpawnManager>();
	}

	private void AssignCompomnentsReferences()
	{
		var wordsController = new WordsController();

		// Input Manager
		inputManager.WordsController = wordsController;

		// Spawn Manager
		spawnManager.WordViewGenerator = GetComponent<WordsViewSpawner>();
		spawnManager.WordsController = wordsController;
		spawnManager.TextGenerator = currentTextGenerator;
		spawnManager.Target = target;
	}

	private ITextGenerator GetTextGenerator()
	{
		ITextGenerator textGenerator;

		if (gameSettings.gameType == GameType.HandsTraining)
		{
			currentDictionaryJson = gameSettings.gameLanguage == GameLanguage.En ? qwertyKeyboardJsonEn : qwertyKeyboardJsonRu;

			var keyboard = JsonHelper.ReadFromAsset<KeyboardQWERTY>(currentDictionaryJson.text);
			if (keyboard == null)
			{
				Debug.LogError("Cannot find dictionary for qwerty text generation!");
				return null;
			}

			var options = new QWERTYOptions(gameSettings.handType, gameSettings.sectionTypes);
			textGenerator = new QWERTYTextGenerator(keyboard, options, minWordLength, maxWordLength);
		}
		else
		{
			currentDictionaryJson = gameSettings.gameLanguage == GameLanguage.En ? wordsArrayJsonEn : wordsArrayJsonRu;
			var wordsDictionary = JsonHelper.ReadFromAsset<string[]>(currentDictionaryJson.text);
			textGenerator = new WordSandboxTextGenerator(wordsDictionary);
		}

		return textGenerator;
	}
}
