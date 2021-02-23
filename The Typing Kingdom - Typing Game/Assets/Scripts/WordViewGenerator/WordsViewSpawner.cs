using UnityEngine;

public class WordsViewSpawner : MonoBehaviour, IWordsViewSpawner
{
	public GameObject prefab;
	public Transform wordCanvas;
	public Camera activeCamera;

	[SerializeField]
	private float offset = 0.1f;

	private void Start()
	{
		if (prefab == null)
			Debug.LogError("Prefab for spawning is null. Please assign a prefab!");

		if (wordCanvas == null)
			wordCanvas = GameObject.FindGameObjectWithTag(Tags.GameCanvas).transform;

		if (activeCamera == null)
			activeCamera = Camera.main;
	}

	public WordView GenerateWordView()
	{
		//Vector3 randomPosition = RandomPointOnUnitCircle(Random.Range(minSpawnRadius, maxSpawnRadius));
		Vector3 randomPosition = GetRandomPositionOutsideCameraView();

		GameObject wordObject = Instantiate(prefab, randomPosition, Quaternion.identity, wordCanvas);
		return wordObject.GetComponent<WordView>();
	}

	public void DeactivateWordView()
	{
		throw new System.NotImplementedException();
	}

	public Vector3 GetRandomPositionOutsideCameraView()
	{
		Vector2 position = new Vector2();
		float verticalOrHorizontal = Random.Range(0f, 1f);

		if (verticalOrHorizontal <= 0.5f) // Vertical
		{
			float upDown = Random.Range(0f, 1f);

			if (upDown <= 0.5)
				position.y += activeCamera.orthographicSize + offset;
			else position.y -= activeCamera.orthographicSize + offset;

			position.x = Random.Range(0f, activeCamera.orthographicSize);
		}
		else // Horizontal
		{
			float leftRight = Random.Range(0f, 1f);

			if (leftRight <= 0.5)
				position.x += activeCamera.orthographicSize * 1.7f + offset;
			else position.x -= activeCamera.orthographicSize * 1.7f + offset;

			position.y = Random.Range(0f, activeCamera.orthographicSize);
		}

		return position;
	}

	public static Vector3 RandomPointOnUnitCircle(float radius)
	{
		float angle = Random.Range(0f, Mathf.PI * 2);
		float x = Mathf.Sin(angle) * radius;
		float y = Mathf.Cos(angle) * radius;

		return new Vector3(x, y);
	}
}
