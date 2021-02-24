using System;
using UnityEngine;

[Serializable]
public class SpawnManager : MonoBehaviour
{
	public WordsController WordsController { get; set; }

	public ITextGenerator TextGenerator { get; set; }

	public IWordsViewSpawner WordViewGenerator { get; set; }

	public Transform TargetTransform { get; set; }
	public Target Target { get; set; }

	public GameSettingsScritable GameSettings { get; set; }

	public PlayerProfileScriptable PlayerProfileForGameScene { get; set; }


	[SerializeField]
	private float secondsBetweenSpawns = 2f;
	private float elapsedTime = 0.0f;
	private float currentWordViewSpeed;
	private int currentWordViewDamage;

	private void Start()
	{
		currentWordViewSpeed = GameSettings.settings.GetSpeedByGameDifficulty();
		currentWordViewDamage = GameSettings.settings.GetDamageByGameDifficulty();
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
		wordView.SetDamage(currentWordViewDamage);
		wordView.target = TargetTransform;
		wordView.currentWord = word;

		wordView.OnCollisionWithDamageReturn += Target.AddDamage;
		wordView.OnCollisionWithWordReturn += WordsController.RemoveWord;

		word.OnTypeLetterUpdateGetUnwrittenPart += wordView.UpdateText;
		word.OnCompleteTypingWord += wordView.RemoveWord;

		word.OnTypeLetterSuccess += PlayerProfileForGameScene.IncreaseSucessType;
		word.OnTypeLetterFailed += PlayerProfileForGameScene.IncreaseUnsucessType;

		word.OnWrittenWordWithoutErrors += PlayerProfileForGameScene.IncreaseWrittenWordsWithoutErrors;
		word.OnWrittenWordWithErrors += PlayerProfileForGameScene.IncreaseWrittenWordsWithErrors;

		WordsController.Add(word);
	}
}

