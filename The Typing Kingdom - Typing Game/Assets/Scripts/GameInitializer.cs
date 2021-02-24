using UnityEngine;

[RequireComponent(typeof(SpawnManager))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(WordsViewSpawner))]
[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(PauseManager))]
public class GameInitializer : MonoBehaviour
{
	[Header("Game Objects")]

	[SerializeField]
	private Transform targetTransform;

	[SerializeField]
	private Target target;

	[Header("Managers")]

	[SerializeField]
	private SpawnManager spawnManager;

	[SerializeField]
	private InputManager inputManager;

	[SerializeField]
	private EventsManager eventsManager;

	[SerializeField]
	private PauseManager pauseManager;

	[SerializeField]
	private Timer timer;

	[Header("Game Settings")]

	[SerializeField]
	private GameSettingsScritable gameSettings;

	[SerializeField]
	[Tooltip("Reference to a player profile of the currently active player. This info will be saved to the game data.")]
	private PlayerProfileScriptable activePlayerProfile;

	[SerializeField]
	[Tooltip("Temporary player profile for saving game state information. This profile will be trigger events for UI.")]
	private PlayerProfileScriptable playerProfileForGameScene;

	[SerializeField]
	private AssetsReferencesScritable assetsReferences;

	private ITextGenerator currentTextGenerator;

	private void Awake()
	{
		if (assetsReferences == null)
		{
			Debug.LogError("Assets with dictiinaries is empty!");
			return;
		}

		var textGeneratorFactory = new TextGeneratorFactory(gameSettings.settings, assetsReferences.assetsReferences);
		currentTextGenerator = textGeneratorFactory.GetTextGenerator();

		if (currentTextGenerator == null)
		{
			Debug.LogError("Cannot create text generator!");
			return;
		}

		target.CurrentDamage = gameSettings.settings.GetDamageByGameDifficulty();

		AssignPlayerProfileEventsToManager();
		AssignTargetEventsToManager();

		AssignPauseEventsFromManager();

		AssignComponents();
		AssignCompomnentsReferences();


		timer.OnTick.AddListener(spawnManager.Spawn);
	}

	private void AssignComponents()
	{
		if (targetTransform == null)
			targetTransform = GameObject.FindGameObjectWithTag(Tags.Player).transform;

		if (inputManager == null)
			inputManager = GetComponent<InputManager>();

		if (spawnManager == null)
			spawnManager = GetComponent<SpawnManager>();

		if (timer == null)
			timer = GetComponent<Timer>();
	}

	private void AssignCompomnentsReferences()
	{
		var wordsController = new WordsController();

		// Input Manager
		inputManager.WordsController = wordsController;

		// Spawn Manager
		spawnManager.Initalize();
		spawnManager.WordViewGenerator = GetComponent<WordsViewSpawner>();
		spawnManager.WordsController = wordsController;
		spawnManager.TextGenerator = currentTextGenerator;
		spawnManager.TargetTransform = targetTransform;
		spawnManager.CurrentWordViewSpeed = gameSettings.settings.GetSpeedByGameDifficulty();
	}

	private void AssignPlayerProfileEventsToManager()
	{
		eventsManager.OnTypeLetterSuccess.AddListener(playerProfileForGameScene.IncreaseSucessType);
		eventsManager.OnTypeLetterFailed.AddListener(playerProfileForGameScene.IncreaseUnsucessType);

		eventsManager.OnWrittenWordWithoutErrors.AddListener(playerProfileForGameScene.IncreaseWrittenWordsWithoutErrors);
		eventsManager.OnWrittenWordWithErrors.AddListener(playerProfileForGameScene.IncreaseWrittenWordsWithErrors);
	}

	private void AssignTargetEventsToManager()
	{
		eventsManager.OnTargetCollisionWithWords.AddListener(target.AddDamage);
	}

	private void AssignPauseEventsFromManager()
	{
		pauseManager.OnPaused.AddListener(() => eventsManager.OnGamePaused?.Invoke());
		pauseManager.OnResume.AddListener(() => eventsManager.OnGameResume?.Invoke());
	}
}
