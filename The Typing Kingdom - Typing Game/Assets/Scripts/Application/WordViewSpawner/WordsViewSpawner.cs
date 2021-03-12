using UnityEngine;

public class WordsViewSpawner : MonoBehaviour, IWordsViewSpawner
{
	public GameObject prefab;

	public Transform target;

	public float wordViewMovingSpeed;


	[Tooltip("Parent canvas transform")]
	public Transform wordCanvas;

	[Tooltip("Camera will be used for generating position outside the camera view")]
	public Camera activeCamera;

	[SerializeField]
	private float offset = 0.1f;

	public IRandomVector3 PositionGenerator { get; set; }

	private void Start()
	{
		if (prefab == null)
			Debug.LogError("Prefab for spawning is null. Please assign a prefab!");

		if (wordCanvas == null)
			wordCanvas = GameObject.FindGameObjectWithTag(Tags.GameCanvas).transform;

		if (activeCamera == null)
			activeCamera = Camera.main;

		PositionGenerator = new Vector3RandomPositionOutsideCameraView(activeCamera, offset);
	}

	public WordView InstantiateWordView()
	{
		Vector3 randomPosition = PositionGenerator.GetRandomVector3Position();
		GameObject wordObject = Instantiate(prefab, randomPosition, Quaternion.identity, wordCanvas);

		var wordView = wordObject.GetComponent<WordView>();
		wordView.SetSpeed(wordViewMovingSpeed);
		wordView.target = target;

		return wordView;
	}

	public void DeactivateWordView()
	{
		throw new System.NotImplementedException();
	}
}
