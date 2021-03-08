using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerProfile", menuName = "ScriptableObjects/PlayerProfile")]
public class PlayerProfileScriptable : ScriptableObject
{
	[SerializeField]
	private PlayerProfile playerProfile;

	public PlayerProfile PlayerProfile
	{
		get { return playerProfile; }
		set { playerProfile = value; }
	}

	private void OnDisable()
	{
		playerProfile.WPM = playerProfile.GetWordsPerMinute();
		playerProfile.totalWordWritten = playerProfile.GetTotalCountOfWrittenWords();
	}

	public void IncreaseElapsedTime(int seconds)
	{
		playerProfile.elapsedTimeInSeconds += seconds;
	}

	public void IncreaseTypeLetterSuccess()
	{
		++playerProfile.successfulInputAttempts;
	}

	public void IncreaseWrittenWordsWithoutErrors()
	{
		++playerProfile.successfulWrittenWords;
	}

	public void IncreaseTypeLetterFailed()
	{
		++playerProfile.failedInputAttempts;
	}

	public void IncreaseWrittenWordsWithErrors()
	{
		++playerProfile.failedWrittenWords;
	}

	public int GetWordsPerMinute()
	{
		return playerProfile.GetWordsPerMinute();
	}

	public int GetTotalCountOfWrittenWords()
	{
		return playerProfile.GetTotalCountOfWrittenWords();
	}

	public int GetTotalCountOfInputAttempts()
	{
		return playerProfile.GetTotalCountOfInputAttempts();
	}
}