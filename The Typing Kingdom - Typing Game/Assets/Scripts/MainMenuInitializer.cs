﻿using UnityEngine;

[RequireComponent(typeof(GameDataManager))]
[RequireComponent(typeof(PlayerProfilesManager))]
[RequireComponent(typeof(SceneManager))]
public class MainMenuInitializer : MonoBehaviour
{
	[Header("Game Settings")]

	[SerializeField]
	private GameDataManager gameDataManager;

	[SerializeField]
	private PlayerProfilesManager playerProfilesManager;

	[SerializeField]
	private PlayerProfileScriptable activePlayerProfile;

	[SerializeField]
	private SceneManager sceneManager;

	private void Awake()
	{
		if (gameDataManager == null)
			gameDataManager = GetComponent<GameDataManager>();

		if (playerProfilesManager == null)
			playerProfilesManager = GetComponent<PlayerProfilesManager>();

		if (activePlayerProfile == null)
			Debug.LogError("Active player profile scriptable is empty!");

		if (sceneManager == null)
			sceneManager = GetComponent<SceneManager>();

		gameDataManager.LoadGameData();
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
}
