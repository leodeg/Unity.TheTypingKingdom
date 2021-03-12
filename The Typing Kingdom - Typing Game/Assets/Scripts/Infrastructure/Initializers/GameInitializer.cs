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

	[SerializeField]
	private ProgressBar targetHealthBar;

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
	private AudioManager audioManager;

	[SerializeField]
	private GameDataManager gameDataManager;

	[SerializeField]
	private PlayerProfilesManager playerProfilesManager;

	[SerializeField]
	private ParticleEffectsManager particleEffectsManager;

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
		if (audioManager == null)
		{
			Debug.LogError("Audio manager is empty");
			return;
		}

		if (particleEffectsManager == null)
		{
			Debug.LogError("Particle effects manager is empty");
			return;
		}

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

		playerProfileForGameScene.Set(new PlayerProfile());

		if (assetsReferences == null)
		{
			Debug.LogError("Assets with dictiinaries is empty!");
			return;
		}

		var textGeneratorFactory = new TextGeneratorFactory(gameSettings.variable, assetsReferences.variable);
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
		AssignAudioEvents();
		AssignVFXEventsToEventsManager();

		pauseManager.ResumeGame();
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
		timer.SecondsBetweenTicks = gameSettings.variable.SecondsBetweenSpawns;

		// Target
		target.CurrentDamage = gameSettings.variable.GetDamageByGameDifficulty();
		target.hitPoints.variable = gameSettings.variable.DefaultHitPointsAmount;

		// Target Health bar
		targetHealthBar.min = 0;
		targetHealthBar.max = target.hitPoints.variable;
		targetHealthBar.current = target.hitPoints.variable;

		// Input Manager
		inputManager.WordsController = wordsController;

		// Audio Manager
		audioManager.audioPlayer.SetMusicVolume(gameSettings.variable.MusicVolume);
		audioManager.audioPlayer.SetSFXVolume(gameSettings.variable.SfxVolume);

		// WordsViewSpawner
		var spawner = GetComponent<WordsViewSpawner>();
		spawner.target = targetTransform;
		spawner.wordViewMovingSpeed = gameSettings.variable.GetSpeedByGameDifficulty();

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
		target.hitPoints.OnSetVariableReturnVariable += targetHealthBar.UpdateProgressBar;
		eventsManager.OnTargetCollisionWithWords.AddListener(target.AddDamage);
	}

	private void AssignPauseEventsFromManager()
	{
		pauseManager.OnPaused.AddListener(() => eventsManager.OnGamePaused?.Invoke());
		pauseManager.OnResume.AddListener(() => eventsManager.OnGameResume?.Invoke());
	}

	private void AssignAudioEvents()
	{
		AssignAudioEffectsToEventsManager(audioManager.audioPlayer, audioManager.audioReferences, eventsManager);
	}

	private void AssignAudioEffectsToEventsManager(AudioPlayer audioPlayer, AudioReferencesScritable audioReferences, EventsManager eventsManager)
	{
		eventsManager.OnTypeLetterSuccess.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.typeSuccess));
		eventsManager.OnTypeLetterFailed.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.typeFailed));
		eventsManager.OnCompleteWord.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.completeWord));

		eventsManager.OnTargetCollisionWithWords.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.collisionWithTarget));
		eventsManager.OnTargetDeath.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.targetDeath));

		eventsManager.OnGameEnd.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.gameEnd));
		eventsManager.OnGamePaused.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.openGameMenu));
	}

	private void AssignVFXEventsToEventsManager()
	{
		eventsManager.OnCompleteWordReturnTransform.AddListener(particleEffectsManager.PlayCompleteWord);
		eventsManager.OnTypeLetterSuccessReturnTransform.AddListener(particleEffectsManager.PlayTypeSuccess);
		eventsManager.OnTypeLetterFailedReturnTransform.AddListener(particleEffectsManager.PlayTypeFailed);

		eventsManager.OnTargetCollisionWithWords.AddListener(() => particleEffectsManager.PlayCollisionWithTarget(targetTransform));
		eventsManager.OnTargetDeath.AddListener(() => particleEffectsManager.PlayTargetDeath(targetTransform));
	}
}
