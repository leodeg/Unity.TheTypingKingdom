using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpawnManager))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(WordsViewSpawner))]
public class GameInitializer : MonoBehaviour
{
	[Header("Game Objects")]

	[SerializeField]
	private Transform target;

	[Header("Managers")]

	[SerializeField]
	private SpawnManager spawnManager;

	[SerializeField]
	private InputManager inputManager;

	[Header("Game Settings")]

	[SerializeField]
	private GameSettingsScritable gameSettings;

	[SerializeField]
	private PlayerProfileScriptable playerStats;

	[SerializeField]
	private AssetsReferencesScritable assetsReferences;

	// Local use fields
	private TextAsset currentDictionaryJson;
	private ITextGenerator currentTextGenerator;

	private void Awake()
	{
		if (assetsReferences == null)
		{
			Debug.LogError("Assets with dictiinaries is empty!");
			return;
		}

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
		spawnManager.GameSettings = gameSettings;
		spawnManager.TextGenerator = currentTextGenerator;
		spawnManager.Target = target;
	}

	// TODO: create text generator factory
	private ITextGenerator GetTextGenerator()
	{
		ITextGenerator textGenerator;

		if (gameSettings.settings.gameType == GameType.HandsTraining)
			textGenerator = GetQWERTYTextGenerator(gameSettings);
		else textGenerator = GetWordSandboxTextGenerator(gameSettings);

		return textGenerator;
	}

	private ITextGenerator GetQWERTYTextGenerator(GameSettingsScritable gameSettings)
	{
		currentDictionaryJson = gameSettings.settings.gameLanguage == GameLanguage.En ?
				assetsReferences.qwertyKeyboardJsonEn : assetsReferences.qwertyKeyboardJsonRu;

		var keyboard = JsonSerializationManager.ReadFromAsset<KeyboardQWERTY>(currentDictionaryJson.text);
		if (keyboard == null)
		{
			Debug.LogError("Cannot find dictionary for qwerty text generation!");
			return null;
		}

		var options = new QWERTYOptions(gameSettings.settings.handType, gameSettings.settings.sectionTypes);
		return new QWERTYTextGenerator(keyboard, options, gameSettings.settings.minWordLength, gameSettings.settings.maxWordLength);
	}

	private ITextGenerator GetWordSandboxTextGenerator(GameSettingsScritable gameSettings)
	{
		currentDictionaryJson = gameSettings.settings.gameLanguage == GameLanguage.En ?
				assetsReferences.wordsArrayJsonEn : assetsReferences.wordsArrayJsonRu;

		var wordsDictionary = JsonSerializationManager.ReadFromAsset<string[]>(currentDictionaryJson.text);
		return new WordSandboxTextGenerator(wordsDictionary);
	}
}
