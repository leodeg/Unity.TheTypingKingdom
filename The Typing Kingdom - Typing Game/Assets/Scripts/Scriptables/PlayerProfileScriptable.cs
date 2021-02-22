using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "PlayerProfile", menuName = "ScriptableObjects/PlayerProfile")]
public class PlayerProfileScriptable : ScriptableObject
{
	[SerializeField]
	private PlayerProfile playerProfile;

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