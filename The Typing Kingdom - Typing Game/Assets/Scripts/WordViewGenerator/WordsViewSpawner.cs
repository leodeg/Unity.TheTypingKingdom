using UnityEngine;

public class WordsViewSpawner : MonoBehaviour, IWordsViewSpawner
{
	public GameObject prefab;

	[Tooltip("Parent canvas transform")]
	public Transform wordCanvas;

	[Tooltip("Camera will be used for generating position outside the camera view")]
	public Camera activeCamera;

	[SerializeField]
	private float offset = 0.1f;

	public IRandomPositionGenerator PositionGenerator { get; set; }

	private void Start()
	{
		if (prefab == null)
			Debug.LogError("Prefab for spawning is null. Please assign a prefab!");

		if (wordCanvas == null)
			wordCanvas = GameObject.FindGameObjectWithTag(Tags.GameCanvas).transform;

		if (activeCamera == null)
			activeCamera = Camera.main;

		PositionGenerator = new Vector3PositionGeneratorOutsideCameraView(activeCamera, offset);
	}

	public WordView GenerateWordView()
	{
		//Vector3 randomPosition = RandomPointOnUnitCircle(Random.Range(minSpawnRadius, maxSpawnRadius));
		Vector3 randomPosition = PositionGenerator.GeneratePosition();

		GameObject wordObject = Instantiate(prefab, randomPosition, Quaternion.identity, wordCanvas);
		return wordObject.GetComponent<WordView>();
	}

	public void DeactivateWordView()
	{
		throw new System.NotImplementedException();
	}
}
