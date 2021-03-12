using UnityEngine;

public class Vector3RandomPositionOnUnitCircle : IRandomVector3
{
	public float Radius { get; set; }

	public Vector3RandomPositionOnUnitCircle(float radius = 1f)
	{
		Radius = radius;
	}

	public Vector3 GetRandomVector3Position()
	{
		float angle = Random.Range(0f, Mathf.PI * 2);
		float x = Mathf.Sin(angle) * Radius;
		float y = Mathf.Cos(angle) * Radius;

		return new Vector3(x, y);
	}
}