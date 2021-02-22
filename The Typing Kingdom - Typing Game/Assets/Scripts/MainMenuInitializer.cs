using UnityEngine;

[RequireComponent(typeof(GameDataManager))]
[RequireComponent(typeof(PlayerProfilesManager))]
public class MainMenuInitializer : MonoBehaviour
{
	[Header("Game Settings")]

	[SerializeField]
	private GameDataManager gameDataManager;

	[SerializeField]
	private PlayerProfilesManager playerProfilesManager;

	private void Awake()
	{
		if (gameDataManager == null)
			gameDataManager = GetComponent<GameDataManager>();

		if (playerProfilesManager == null)
			playerProfilesManager = GetComponent<PlayerProfilesManager>();

		gameDataManager.LoadGameData();
	}

	private void Start()
	{

	}
}