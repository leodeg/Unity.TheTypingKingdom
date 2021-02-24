using System;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
	public UnityEvent OnTick;

	[SerializeField]
	private float secondsBetweenSpawns = 2f;
	private float elapsedTime = 0.0f;

	public float SecondsBetweenSpawns { get => secondsBetweenSpawns; set => secondsBetweenSpawns = value; }

	void Update()
	{
		elapsedTime += Time.deltaTime;
		if (elapsedTime > secondsBetweenSpawns)
		{
			elapsedTime = 0;
			OnTick?.Invoke();
		}
	}
}