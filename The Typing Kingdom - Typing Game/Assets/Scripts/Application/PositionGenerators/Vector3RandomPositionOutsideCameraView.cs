using UnityEngine;

public class Vector3RandomPositionOutsideCameraView : IRandomVector3
{
	public Camera Camera { get; set; }

	[SerializeField]
	private float Offset { get; set; }

	public Vector3RandomPositionOutsideCameraView(Camera camera, float offset = 0.1f)
	{
		Camera = camera;
		Offset = offset;
	}

	public Vector3 GetRandomVector3Position()
	{
		Vector2 position = new Vector2();
		float verticalOrHorizontal = Random.Range(0f, 1f);

		if (verticalOrHorizontal <= 0.5f) // Vertical
		{
			float upDown = Random.Range(0f, 1f);

			if (upDown <= 0.5)
				position.y += Camera.orthographicSize + Offset;
			else position.y -= Camera.orthographicSize + Offset;

			position.x = Random.Range(0f, Camera.orthographicSize);
		}
		else // Horizontal
		{
			float leftRight = Random.Range(0f, 1f);

			if (leftRight <= 0.5)
				position.x += Camera.orthographicSize * 1.7f + Offset;
			else position.x -= Camera.orthographicSize * 1.7f + Offset;

			position.y = Random.Range(0f, Camera.orthographicSize);
		}

		return position;
	}
}
