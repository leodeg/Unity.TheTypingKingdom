using UnityEngine;

[RequireComponent(typeof(SpawnManager))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(WordsViewSpawner))]
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

	[Header("Game Settings")]

	[SerializeField]
	private GameSettingsScritable gameSettings;

	[SerializeField]
	private PlayerProfileScriptable playerStats;

	[SerializeField]
	private AssetsReferencesScritable assetsReferences;

	// Local use fields
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

		AssignComponents();
		AssignCompomnentsReferences();
	}

	private void AssignComponents()
	{
		if (targetTransform == null)
			targetTransform = GameObject.FindGameObjectWithTag(Tags.Player).transform;

		if (inputManager == null)
			inputManager = GetComponent<InputManager>();

		if (spawnManager == null)
			spawnManager = GetComponent<SpawnManager>();
	}

	private void AssignCompomnentsReferences()
	{
		var wordsController = new WordsController();

		// Input Manager
		inputManager.WordsController = wordsController;

		// Spawn Manager
		spawnManager.WordViewGenerator = GetComponent<WordsViewSpawner>();
		spawnManager.WordsController = wordsController;
		spawnManager.GameSettings = gameSettings;
		spawnManager.TextGenerator = currentTextGenerator;
		spawnManager.TargetTransform = targetTransform;
		spawnManager.Target = target;
	}
}
