using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SpawnManager : MonoBehaviour
{
	public WordsController WordsController { get; set; }

	public ITextGenerator TextGenerator { get; set; }

	public IWordsViewSpawner WordViewGenerator { get; set; }

	public Transform Target { get; set; }


	[SerializeField]
	private float secondsBetweenSpawns = 2f;

	private float elapsedTime = 0.0f;

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
		wordView.target = Target;

		word.OnTypeLetterUpdate += wordView.UpdateText;
		word.OnCompleteTypingWord += wordView.RemoveWord;

		WordsController.Add(word);
	}
}
