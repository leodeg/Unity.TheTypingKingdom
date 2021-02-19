using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordsViewGenerator : MonoBehaviour, IWordsViewGenerator
{
	public GameObject prefab;
	public Transform wordCanvas;

	[SerializeField]
	private float minSpawnRadius = 15;
	[SerializeField]
	private float maxSpawnRadius = 40;

	public WordView GenerateView()
	{
		Vector2 randomPosition = RandomPointOnUnitCircle(Random.Range(minSpawnRadius, maxSpawnRadius));
		GameObject wordObject = Instantiate(prefab, randomPosition, Quaternion.identity, wordCanvas);
		return wordObject.GetComponent<WordView>();
	}

	public void DeactivateWordView()
	{
		throw new System.NotImplementedException();
	}

	public static Vector2 RandomPointOnUnitCircle(float radius)
	{
		float angle = Random.Range(0f, Mathf.PI * 2);
		float x = Mathf.Sin(angle) * radius;
		float y = Mathf.Cos(angle) * radius;

		return new Vector2(x, y);
	}
}
