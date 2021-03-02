using UnityEngine;

public class Vector3PositionGeneratorOnUnitCircle : IRandomPositionGenerator
{
	public float Radius { get; set; }

	public Vector3PositionGeneratorOnUnitCircle(float radius = 1f)
	{
		Radius = radius;
	}

	public Vector3 GeneratePosition()
	{
		float angle = Random.Range(0f, Mathf.PI * 2);
		float x = Mathf.Sin(angle) * Radius;
		float y = Mathf.Cos(angle) * Radius;

		return new Vector3(x, y);
	}
}