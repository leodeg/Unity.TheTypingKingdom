using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSpawnController : MonoBehaviour
{
	[SerializeField]
	public WordsController WordController { get; set; }

	[SerializeField]
	public ITextGenerator TextGenerator { get; set; }

	[SerializeField, SerializeReference]
	public WordsViewGenerator wordViewGenerator;

	[SerializeField]
	private Transform target;

	[SerializeField]
	private float secondsBetweenSpawn = 2f;

	private float elapsedTime = 0.0f;

	void Update()
	{
		elapsedTime += Time.deltaTime;
		if (elapsedTime > secondsBetweenSpawn)
		{
			elapsedTime = 0;
			SpawnNewWord();
		}
	}

	public void SpawnNewWord()
	{
		Word word = new Word(TextGenerator.GenerateText());

		WordView wordView = wordViewGenerator.GenerateView();
		wordView.SetText(word.GetFullWord());
		wordView.target = target;

		word.OnTypeLetterUpdate += wordView.UpdateText;
		word.OnCompleteTypingWord += wordView.RemoveWord;

		WordController.Add(word);
	}
}
