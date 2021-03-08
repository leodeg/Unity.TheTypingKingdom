using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class PlayerProfilesContainer
{
	private Dictionary<string, PlayerProfile> playerProfiles;

	public PlayerProfilesContainer()
	{
		playerProfiles = new Dictionary<string, PlayerProfile>();
	}

	public IEnumerable<PlayerProfile> GetPlayerProfiles()
	{
		return playerProfiles.Values.ToList();
	}

	public IEnumerable<string> GetPlayerProfilesNames()
	{
		return playerProfiles.Values.Select(profile => profile.playerName);
	}

	public bool TryGetPlayerProfile(string playerName, out PlayerProfile playerProfile)
	{
		return playerProfiles.TryGetValue(playerName, out playerProfile);
	}

	public PlayerProfile CreateOrFindPlayerProfile(string playerName)
	{
		if (CreateNewPlayerProfile(playerName, new PlayerProfile()))
		{
			PlayerProfile playerProfile;

			if (playerProfiles.TryGetValue(playerName, out playerProfile))
				return playerProfile;
		}

		return null;
	}

	public bool CreateNewPlayerProfile(string playerName, PlayerProfile playerProfile)
	{
		if (playerProfiles.ContainsKey(playerName))
		{
			Debug.LogError($"Player profile with name [{playerName}] already exists!");
			return false;
		}

		if (string.IsNullOrEmpty(playerProfile.playerName))
		{
			playerProfile.playerName = playerName;
		}

		playerProfiles.Add(playerName, playerProfile);
		return true;
	}

	public bool UpdateValue(string playerName, PlayerProfile newValue)
	{
		if (playerProfiles.ContainsKey(playerName))
		{
			playerProfiles[playerName] = newValue;
			return true;
		}

		return false;
	}

	public override string ToString()
	{
		var builder = new StringBuilder();

		foreach (var playerProfile in playerProfiles.Values)
		{
			builder.Append(playerProfile.ToString());
			builder.AppendLine("\n");
		}

		return builder.ToString();
	}
}