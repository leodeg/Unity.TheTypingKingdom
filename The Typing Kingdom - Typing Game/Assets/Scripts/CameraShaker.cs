using UnityEngine;
using UnityEngine.Events;

public class CameraShaker : MonoBehaviour
{
	[SerializeField] private Camera activeCamera;
	[SerializeField] private float speed;
	[SerializeField] private float duration;
	[SerializeField] private Vector3 amount;
	[SerializeField] private AnimationCurve curve = AnimationCurve.EaseInOut(0, 1, 1, 0);

	private float time;

	private Vector3 lastPosition;
	private float lastFieldOfView;

	private Vector3 nextPosition;
	private float nextFieldOfView;

	public Camera ActiveCamera { get { return activeCamera; } set { activeCamera = value; } }

	private void Start()
	{
		if (activeCamera == null)
			Debug.LogError("Active camera for shaking not assigned!");
	}

	private void LateUpdate()
	{
		ShakeCamera();
	}

	public void Shake ()
	{
		time = duration;
		ResetCamera();
	}

	private void ShakeCamera()
	{
		if (time > 0)
		{
			time -= Time.deltaTime;

			if (time <= 0)
			{
				ResetCamera();
				return;
			}

			float horizontalPerlinNoise = Mathf.PerlinNoise(time * speed, time * speed * 2) - 0.5f;
			float verticalPerlinNoise = Mathf.PerlinNoise(time * speed * 2, time * speed) - 0.5f;
			float forwardPerlinNoise = Mathf.PerlinNoise(time * speed * 2, time * speed * 2) - 0.5f;

			nextPosition = horizontalPerlinNoise * amount.x * transform.right * curve.Evaluate(1f - time / duration) + 
				verticalPerlinNoise * amount.y * transform.up * curve.Evaluate(1f - time / duration);
			nextFieldOfView = forwardPerlinNoise * amount.z * curve.Evaluate(1f - time / duration);

			activeCamera.fieldOfView += nextFieldOfView - lastFieldOfView;
			activeCamera.transform.Translate(nextPosition - lastPosition);

			lastPosition = nextPosition;
			lastFieldOfView = nextFieldOfView;
		}
	}

	public void ResetCamera()
	{
		lastPosition = nextPosition = Vector3.zero;
		lastFieldOfView = nextFieldOfView = 0f;
	}
}