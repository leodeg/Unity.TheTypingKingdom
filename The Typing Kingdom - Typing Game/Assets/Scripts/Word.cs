using System;
using UnityEngine.UI;

public class Word
{
	public event Action<string> OnTypeLetterUpdate;
	public event Action OnTypeLetterFailed;
	public event Action OnTypeLetterSuccess;
	public event Action OnCompleteTypingWord;

	private string word;
	private int currentLetterIndex;

	public Word(string word)
	{
		this.word = word;
		currentLetterIndex = 0;
	}

	public bool RemoveCurrentLetter(char letter)
	{
		if (GetCurrentLetter() != letter)
		{
			OnTypeLetterFailed?.Invoke();
			return false;
		}

		MoveToNextLetter();
		OnTypeLetterSuccess?.Invoke();

		if (IsTyped())
		{
			OnCompleteTypingWord?.Invoke();
			return true;
		}

		OnTypeLetterUpdate?.Invoke(GetUnwrittenPartOfWord());
		return true;
	}
	public bool IsTyped()
	{
		return currentLetterIndex >= word.Length;
	}

	public void MoveToNextLetter()
	{
		++currentLetterIndex;
	}

	public char GetCurrentLetter()
	{
		return word[currentLetterIndex];
	}

	public string GetFullWord()
	{
		return word;
	}

	public string GetWrittenPartOfWord()
	{
		if (currentLetterIndex > 0)
			return word.Substring(0, currentLetterIndex);
		return string.Empty;
	}

	public string GetUnwrittenPartOfWord()
	{
		if (currentLetterIndex <= word.Length - 1)
			return word.Substring(currentLetterIndex, word.Length - currentLetterIndex);
		return string.Empty;
	}
}
