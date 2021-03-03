using UnityEngine;

public class GameDataManager : MonoBehaviour
{
	private const string DefaultSaveFileName = "Save.save";

	[SerializeField]
	private PlayerProfilesManager playerProfilesManager;

	[SerializeField]
	[Tooltip("Reference to a player profile of the currently active player. This info will be saved to the game data.")]
	private PlayerProfileScriptable activePlayerProfile;

	[SerializeField]
	[Tooltip("Temporary player profile for saving game state information. This profile will be trigger events for UI.")]
	private PlayerProfileScriptable playerProfileForGameScene;

	[SerializeField]
	private TimeCounter timeCounter;

	private void Awake()
	{
		if (playerProfilesManager == null)
			Debug.LogError("Player profiles manager is empty");

		if (activePlayerProfile == null)
			Debug.LogError("Active player profile scriptable is empty");

		if (playerProfileForGameScene == null)
			Debug.LogError("Temprorary player profile scriptable is empty");
	}

	public void SaveGameData()
	{
		BinarySerializationManager.Save(DefaultSaveFileName, GameData.Instance);
	}

	public void LoadGameData()
	{
		GameData.Instance = BinarySerializationManager.Load(DefaultSaveFileName) as GameData;
	}

	public void SavePlayerProfileToScriptable()
	{
		if (activePlayerProfile == null)
		{
			Debug.LogError("Active player profile scriptable is empty!");
			return;
		}

		if (playerProfilesManager.CurrenPlayerProfile == null)
		{
			Debug.LogError("The player profile was not selected. Please select player profile!");
			return;
		}

		activePlayerProfile.PlayerProfile = playerProfilesManager.CurrenPlayerProfile;
	}

	public void SaveGameResultsToGameData()
	{
		if (playerProfileForGameScene == null)
		{
			Debug.LogError("Temprorary player profile scriptable is empty");
			return;
		}

		playerProfileForGameScene.PlayerProfile.elapsedTimeInSeconds = Mathf.RoundToInt(timeCounter.TimePassed);

		activePlayerProfile.PlayerProfile.AddStats(playerProfileForGameScene.PlayerProfile);

		playerProfilesManager.UpdateProfile(activePlayerProfile.PlayerProfile.playerName, activePlayerProfile.PlayerProfile);

		SaveGameData();
	}
}