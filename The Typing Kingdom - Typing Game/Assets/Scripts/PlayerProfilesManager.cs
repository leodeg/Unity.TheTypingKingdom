using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

// TODO: Don't destroy on load
public class PlayerProfilesManager : MonoBehaviour
{
	public string CurrentPlayerName { get; set; }
	public PlayerProfile CurrenPlayerProfile { get; set; }

	public UnityEvent OnCreateNewProfile;

	public IEnumerable<string> GetListOfProfilesNames()
	{
		return GameData.Instance.PlayerProfiles.GetPlayerProfilesNames();
	}

	public void AssignCurrentPlayerProfile(string playerName)
	{
		CurrenPlayerProfile = FindPlayerProfile(playerName);
		Debug.Log(CurrenPlayerProfile.playerName);
	}

	public PlayerProfile FindPlayerProfile(string playerName)
	{
		PlayerProfile playerProfile;
		GameData.Instance.PlayerProfiles.TryGetPlayerProfile(playerName, out playerProfile);
		return playerProfile;
	}

	public void CreateNewProfile()
	{
		if (string.IsNullOrEmpty(this.CurrentPlayerName))
		{
			Debug.LogError("Player name is null or empty");
			return;
		}

		CreateNewProfile(this.CurrentPlayerName);
	}

	public void CreateNewProfile(string playerName)
	{
		CurrenPlayerProfile = GameData.Instance.PlayerProfiles.CreateOrFindPlayerProfile(playerName);
		CurrentPlayerName = playerName;
		OnCreateNewProfile?.Invoke();

		Debug.Log(CurrenPlayerProfile.playerName);
		Debug.Log(GameData.Instance.PlayerProfiles.GetPlayerProfiles().Count());
	}
}
