using UnityEngine;

[RequireComponent(typeof(SpawnManager))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(WordsViewSpawner))]
[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(TimeCounter))]
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
	private GameDataManager gameDataManager;

	[SerializeField]
	private PlayerProfilesManager playerProfilesManager;

	[SerializeField]
	private Timer timer;

	[SerializeField]
	private TimeCounter timeCounter;

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
		if (activePlayerProfile == null)
		{
			Debug.LogError("Active player profile is empty");
			return;
		}

		if (playerProfileForGameScene == null)
		{
			Debug.LogError("Temprory player profile is empty");
			return;
		}

		playerProfileForGameScene.PlayerProfile = new PlayerProfile();

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

		// Components
		AssignComponents();
		AssignCompomnentsReferences();

		// Events
		AssignPlayerProfileEventsToManager();
		AssignTargetEventsToManager();
		AssignPauseEventsFromManager();

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

		if (timeCounter == null)
			timeCounter = GetComponent<TimeCounter>();
	}

	private void AssignCompomnentsReferences()
	{
		var wordsController = new WordsController();
		wordsController.OnTypeLetterFailed += () => eventsManager.OnTypeLetterFailed?.Invoke();

		//Timer
		timer.SecondsBetweenSpawns = gameSettings.settings.SecondsBetweenSpawns;

		// Target
		target.CurrentDamage = gameSettings.settings.GetDamageByGameDifficulty();

		// Input Manager
		inputManager.WordsController = wordsController;

		// WordsViewSpawner
		var spawner = GetComponent<WordsViewSpawner>();
		spawner.target = targetTransform;
		spawner.wordViewMovingSpeed = gameSettings.settings.GetSpeedByGameDifficulty();

		// Spawn Manager
		spawnManager.WordViewGenerator = GetComponent<WordsViewSpawner>();
		spawnManager.WordsController = wordsController;
		spawnManager.TextGenerator = currentTextGenerator;
		spawnManager.EventsManager = eventsManager;
	}

	private void AssignPlayerProfileEventsToManager()
	{
		eventsManager.OnTypeLetterSuccess.AddListener(playerProfileForGameScene.IncreaseTypeLetterSuccess);
		eventsManager.OnTypeLetterFailed.AddListener(playerProfileForGameScene.IncreaseTypeLetterFailed);

		eventsManager.OnWrittenWordWithoutErrors.AddListener(playerProfileForGameScene.IncreaseWrittenWordsWithoutErrors);
		eventsManager.OnWrittenWordWithErrors.AddListener(playerProfileForGameScene.IncreaseWrittenWordsWithErrors);
	}

	private void AssignTargetEventsToManager()
	{
		target.OnTargetDeath.AddListener(() => eventsManager.OnGameEnd?.Invoke());
		eventsManager.OnTargetCollisionWithWords.AddListener(target.AddDamage);
	}

	private void AssignPauseEventsFromManager()
	{
		pauseManager.OnPaused.AddListener(() => eventsManager.OnGamePaused?.Invoke());
		pauseManager.OnResume.AddListener(() => eventsManager.OnGameResume?.Invoke());
	}
}
