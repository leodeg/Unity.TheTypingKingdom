using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/PlayerStats")]
public class PlayerStatsScriptable : ScriptableObject
{
	[Header("Player Info")]
	public string fullName;

	[Header("Written Words Statistics")]

	public int successfulWrittenWords;
	public int failedWrittenWords;

	[Header("Attempts Statistics")]

	public int successfulInputAttempts;
	public int failedInputAttempts;

	[Header("Game Statistics")]
	public int WPM;
	public int totalWordWritten;
	public int elapsedTimeInSeconds;

	private void OnDisable()
	{
		WPM = GetWordsPerMinute();
		totalWordWritten = GetTotalCountOfWrittenWords();
	}

	public int GetWordsPerMinute()
	{
		// Number_of_keystroke / time_in_minute * percentages_of_accurate_word
		// Number_of_keystroke / time_in_second * 60 * percentages_of_accurate_word

		if (GetTotalCountOfWrittenWords() < 1)
			return 0;

		var percentagesOfAccurateWords = (successfulWrittenWords / GetTotalCountOfWrittenWords()) * 100;
		var wpm = GetTotalCountOfInputAttempts() / elapsedTimeInSeconds * 60 * percentagesOfAccurateWords;
		return Mathf.RoundToInt(wpm);
	}

	private int GetTotalCountOfWrittenWords()
	{
		return successfulWrittenWords + failedWrittenWords;
	}

	private int GetTotalCountOfInputAttempts()
	{
		return successfulInputAttempts + failedInputAttempts;
	}
}