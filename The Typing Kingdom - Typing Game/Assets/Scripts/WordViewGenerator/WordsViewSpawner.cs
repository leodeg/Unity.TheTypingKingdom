using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsViewSpawner : MonoBehaviour, IWordsViewSpawner
{
	public GameObject prefab;
	public Transform wordCanvas;

	[SerializeField]
	private float minSpawnRadius = 15;

	[SerializeField]
	private float maxSpawnRadius = 40;

	private void Start()
	{
		if (prefab == null)
			Debug.LogError("Prefab for spawning is null. Please assign a prefab!");

		if (wordCanvas == null)
			wordCanvas = GameObject.FindGameObjectWithTag(Tags.GameCanvas).transform;
	}

	public WordView GenerateWordView()
	{
		Vector3 randomPosition = RandomPointOnUnitCircle(Random.Range(minSpawnRadius, maxSpawnRadius));
		GameObject wordObject = Instantiate(prefab, randomPosition, Quaternion.identity, wordCanvas);
		return wordObject.GetComponent<WordView>();
	}

	public void DeactivateWordView()
	{
		throw new System.NotImplementedException();
	}

	public static Vector3 RandomPointOnUnitCircle(float radius)
	{
		float angle = Random.Range(0f, Mathf.PI * 2);
		float x = Mathf.Sin(angle) * radius;
		float y = Mathf.Cos(angle) * radius;

		return new Vector3(x, y);
	}
}
