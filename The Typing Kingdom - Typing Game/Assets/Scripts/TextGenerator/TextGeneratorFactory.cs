using UnityEngine;

public class TextGeneratorFactory
{
	private readonly GameSettings gameSettings;
	private readonly AssetsReferences assetsReferences;
	private TextAsset currentDictionaryJson;

	public TextGeneratorFactory(GameSettings gameSettings, AssetsReferences assetsReferences)
	{
		this.gameSettings = gameSettings;
		this.assetsReferences = assetsReferences;
	}

	public ITextGenerator GetTextGenerator()
	{
		ITextGenerator textGenerator;

		if (gameSettings.gameType == GameType.HandsTraining)
			textGenerator = GetQWERTYTextGenerator(gameSettings);
		else textGenerator = GetWordSandboxTextGenerator(gameSettings);

		return textGenerator;
	}

	public ITextGenerator GetQWERTYTextGenerator()
	{
		return GetQWERTYTextGenerator(gameSettings);
	}

	private ITextGenerator GetQWERTYTextGenerator(GameSettings gameSettings)
	{
		currentDictionaryJson = gameSettings.gameLanguage == GameLanguage.En ?
				assetsReferences.qwertyKeyboardJsonEn : assetsReferences.qwertyKeyboardJsonRu;

		var keyboard = JsonSerializationManager.ReadFromAsset<KeyboardQWERTY>(currentDictionaryJson.text);
		if (keyboard == null)
		{
			Debug.LogError("Cannot find dictionary for qwerty text generation!");
			return null;
		}

		var options = new QWERTYOptions(gameSettings.handType, gameSettings.sectionTypes);
		return new QWERTYTextGenerator(keyboard, options, gameSettings.minWordLength, gameSettings.maxWordLength);
	}

	public ITextGenerator GetWordSandboxTextGenerator()
	{
		return GetWordSandboxTextGenerator(gameSettings);
	}

	private ITextGenerator GetWordSandboxTextGenerator(GameSettings gameSettings)
	{
		currentDictionaryJson = gameSettings.gameLanguage == GameLanguage.En ?
				assetsReferences.wordsArrayJsonEn : assetsReferences.wordsArrayJsonRu;

		var wordsDictionary = JsonSerializationManager.ReadFromAsset<string[]>(currentDictionaryJson.text);
		return new WordSandboxTextGenerator(wordsDictionary);
	}
}