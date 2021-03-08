using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "ScriptableObjects/PlayerProfile")]
public class PlayerProfileScriptable : ScriptableVariable<PlayerProfile>
{
	private void OnDisable()
	{
		variable.WPM = variable.GetWordsPerMinute();
		variable.totalWordWritten = variable.GetTotalCountOfWrittenWords();
	}

	public void IncreaseElapsedTime(int seconds)
	{
		variable.elapsedTimeInSeconds += seconds;
	}

	public void IncreaseTypeLetterSuccess()
	{
		++variable.successfulInputAttempts;
	}

	public void IncreaseWrittenWordsWithoutErrors()
	{
		++variable.successfulWrittenWords;
	}

	public void IncreaseTypeLetterFailed()
	{
		++variable.failedInputAttempts;
	}

	public void IncreaseWrittenWordsWithErrors()
	{
		++variable.failedWrittenWords;
	}

	public int GetWordsPerMinute()
	{
		return variable.GetWordsPerMinute();
	}

	public int GetTotalCountOfWrittenWords()
	{
		return variable.GetTotalCountOfWrittenWords();
	}

	public int GetTotalCountOfInputAttempts()
	{
		return variable.GetTotalCountOfInputAttempts();
	}
}