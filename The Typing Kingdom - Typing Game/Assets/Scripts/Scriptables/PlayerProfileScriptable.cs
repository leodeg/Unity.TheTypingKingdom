using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerProfile", menuName = "ScriptableObjects/PlayerProfile")]
public class PlayerProfileScriptable : ScriptableObject
{
	[SerializeField]
	private PlayerProfile playerProfile;

	public UnityEvent OnSuccessType;
	public UnityEvent OnUnsuccessType;
	public UnityEvent OnCompleteWord;

	public PlayerProfile PlayerStats
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

	public void IncreaseSucessType()
	{
		++playerProfile.successfulInputAttempts;
	}

	public void IncreaseWrittenWordsWithoutErrors()
	{
		++playerProfile.successfulWrittenWords;
	}

	public void IncreaseUnsucessType()
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