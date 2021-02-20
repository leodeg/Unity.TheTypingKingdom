using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerProfile
{
	[Header("Player Info")]
	public string playerName;

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

	public int GetTotalCountOfWrittenWords()
	{
		return successfulWrittenWords + failedWrittenWords;
	}

	public int GetTotalCountOfInputAttempts()
	{
		return successfulInputAttempts + failedInputAttempts;
	}
}
