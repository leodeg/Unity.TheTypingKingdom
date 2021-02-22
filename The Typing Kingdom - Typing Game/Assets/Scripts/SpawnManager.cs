using System;
using UnityEngine;

[Serializable]
public class SpawnManager : MonoBehaviour
{
	public WordsController WordsController { get; set; }

	public ITextGenerator TextGenerator { get; set; }

	public IWordsViewSpawner WordViewGenerator { get; set; }

	public Transform Target { get; set; }

	public GameSettingsScritable GameSettings { get; set; }


	[SerializeField]
	private float secondsBetweenSpawns = 2f;
	private float elapsedTime = 0.0f;
	private float currentWordViewSpeed;

	private void Start()
	{
		currentWordViewSpeed = GetSpeedByGameDifficulty();
	}

	void Update()
	{
		elapsedTime += Time.deltaTime;
		if (elapsedTime > secondsBetweenSpawns)
		{
			elapsedTime = 0;
			Spawn();
		}
	}

	public void Spawn()
	{
		Word word = new Word(TextGenerator.GenerateText());

		WordView wordView = WordViewGenerator.GenerateWordView();
		wordView.SetText(word.GetFullWord());
		wordView.SetSpeed(currentWordViewSpeed);
		wordView.target = Target;

		word.OnTypeLetterUpdateGetUnwrittenPart += wordView.UpdateText;
		word.OnCompleteTypingWord += wordView.RemoveWord;

		WordsController.Add(word);
	}

	public float GetSpeedByGameDifficulty()
	{
		switch (GameSettings.settings.gameDifficulty)
		{
			case GameDifficulty.Easy: return GameSettings.settings.easyGameSpeed;
			case GameDifficulty.Medium: return GameSettings.settings.mediumGameSpeed;
			case GameDifficulty.Hard: return GameSettings.settings.hardGameSpeed;
			case GameDifficulty.God: return GameSettings.settings.godGameSpeed;
			default: return GameSettings.settings.easyGameSpeed;
		}
	}
}
