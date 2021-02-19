using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpawnManager))]
[RequireComponent(typeof(InputManager))]
public class GameInitializer : MonoBehaviour
{
	[SerializeField]
	private SpawnManager spawnController;

	[SerializeField]
	private WordsViewSpawner wordsViewGenerator;

	[SerializeField]
	private InputManager inputController;

	[SerializeReference]
	private Transform target;

	private void Awake()
	{
		target = GameObject.FindGameObjectWithTag(Tags.Player).transform;

		var wordsController = new WordsController();

		inputController = GetComponent<InputManager>();
		inputController.WordsController = wordsController;

		wordsViewGenerator = GetComponent<WordsViewSpawner>();
		spawnController.WordViewGenerator = wordsViewGenerator;
		spawnController.TextGenerator = new FakeTextGenerator();
		spawnController.WordsController = wordsController;
		spawnController.Target = target;
	}

	private void Start()
	{

	}
}
