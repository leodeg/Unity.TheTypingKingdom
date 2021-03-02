using System;

public class Word
{
	public event Action<string> OnTypeLetterUpdateReturnUnwrittenPart;
	public event Action<string> OnTypeLetterUpdateReturnWrittenPart;

	public event Action OnTypeLetterFailed;
	public event Action OnTypeLetterSuccess;

	public event Action OnWrittenWordWithoutErrors;
	public event Action OnWrittenWordWithErrors;

	public event Action OnCompleteTypingWord;

	private string word;
	private int currentLetterIndex;
	private bool isWordWrittenWithError = false;

	public Word(string word)
	{
		this.word = word;
		currentLetterIndex = 0;
	}

	public bool RemoveCurrentLetter(char letter)
	{
		if (GetCurrentLetter() != letter)
		{
			isWordWrittenWithError = true;
			OnTypeLetterFailed?.Invoke();
			return false;
		}

		MoveToNextLetter();
		OnTypeLetterSuccess?.Invoke();

		if (IsTyped())
		{
			OnCompleteTypingWord?.Invoke();

			if (isWordWrittenWithError)
				OnWrittenWordWithErrors?.Invoke();
			else OnWrittenWordWithoutErrors?.Invoke();

			return true;
		}

		OnTypeLetterUpdateReturnUnwrittenPart?.Invoke(GetUnwrittenPartOfWord());
		OnTypeLetterUpdateReturnWrittenPart?.Invoke(GetWrittenPartOfWord());
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
