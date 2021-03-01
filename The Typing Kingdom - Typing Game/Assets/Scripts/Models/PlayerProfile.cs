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

	public void AddStats(PlayerProfile playerProfileStats)
	{
		successfulWrittenWords += playerProfileStats.successfulWrittenWords;
		failedWrittenWords += playerProfileStats.failedWrittenWords;
		successfulInputAttempts += playerProfileStats.successfulInputAttempts;
		failedInputAttempts += playerProfileStats.failedInputAttempts;
		elapsedTimeInSeconds += playerProfileStats.elapsedTimeInSeconds;

		WPM = GetWordsPerMinute();
		totalWordWritten = GetTotalCountOfWrittenWords();
	}

	public int GetWordsPerMinute()
	{
		// Number_of_keystroke / time_in_minute * percentages_of_accurate_word
		// Number_of_keystroke / time_in_second * 60 * percentages_of_accurate_word

		var totalCountOfWrittenWords = GetTotalCountOfWrittenWords();
		var totalCountOfInputAttempts = GetTotalCountOfInputAttempts();

		if (totalCountOfWrittenWords < 1 || totalCountOfInputAttempts < 1 || elapsedTimeInSeconds < 1)
			return 0;

		var percentagesOfAccurateWords = (successfulWrittenWords / totalCountOfWrittenWords) * 100;
		var wpm = totalCountOfInputAttempts / elapsedTimeInSeconds * 60 * percentagesOfAccurateWords;
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

	public override string ToString()
	{
		return $"Player name: {playerName} \n" +
			$"SuccessfulWrittenWords: {successfulWrittenWords} \n" +
			$"FailedWrittenWords: {failedWrittenWords} \n" +
			$"SuccessfulInputAttempts: {successfulInputAttempts} \n" +
			$"FailedInputAttempts: {failedInputAttempts} \n" +
			$"Words per Minute: {WPM} \n" +
			$"Total written words: {totalWordWritten} \n" +
			$"ElapsedTimeInSeconds: {elapsedTimeInSeconds}";
	}
}
