using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerProfilesManager : MonoBehaviour
{
	public string CurrentPlayerName { get; set; }
	public PlayerProfile CurrenPlayerProfile { get; set; }

	public UnityEvent OnCreateNewProfile;

	public PlayerProfile FindPlayerProfile(string playerName)
	{
		PlayerProfile playerProfile;
		SaveData.Instance.PlayerProfiles.TryGetPlayerProfile(playerName, out playerProfile);
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
		CurrenPlayerProfile = SaveData.Instance.PlayerProfiles.CreateOrFindPlayerProfile(playerName);
		CurrentPlayerName = playerName;
		OnCreateNewProfile?.Invoke();

		Debug.Log(CurrenPlayerProfile.playerName);
		Debug.Log(SaveData.Instance.PlayerProfiles.GetPlayerProfiles().Count());
	}
}