
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordsController
{
	public event Action OnTypeLetterFailed;

	private List<Word> words = new List<Word>();
	private Word activeWord;

	public void Add(Word word)
	{
		words.Add(word);
		word.OnCompleteTypingWord += RemoveActiveWord;
	}

	public void ProcessInput(char input)
	{
		if (activeWord != null)
		{
			if (activeWord.RemoveCurrentLetter(input))
				DebugLogOfRemovedLetter(input);
			return;
		}

		var word = words.FirstOrDefault(w => w.GetCurrentLetter() == input);

		if (word == null)
		{
			OnTypeLetterFailed?.Invoke();
			Debug.Log($"Letter [{input}] was not found from words list!");
			return;
		}

		activeWord = word;
		activeWord.RemoveCurrentLetter(input);
		DebugLogOfRemovedLetter(input);
	}

	private void DebugLogOfRemovedLetter(char input)
	{
		if (activeWord == null)
			return;

		Debug.Log($"Letter [{input}] was removed from word {activeWord.GetFullWord()}");
		Debug.Log($"Written part: {activeWord.GetWrittenPartOfWord()}");
		Debug.Log($"Unwritten part: {activeWord.GetUnwrittenPartOfWord()}");
	}

	private void RemoveActiveWord()
	{
		if (activeWord == null)
		{
			Debug.LogError($"Cannot remove active word because it's null!");
			return;
		}

		words.Remove(activeWord);
		activeWord = null;
	}

	public void RemoveWord(Word word)
	{
		words.Remove(word);
		if (activeWord == word)
			activeWord = null;
	}
}
