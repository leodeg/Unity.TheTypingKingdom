using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
	public float secondsBetweenTicks = 2;
	public UnityEvent OnTick;

	private float elapsedTime = 0.0f;

	public float SecondsBetweenTicks { get => secondsBetweenTicks; set => secondsBetweenTicks = value; }

	void Update()
	{
		elapsedTime += Time.deltaTime;
		if (elapsedTime > secondsBetweenTicks)
		{
			elapsedTime = 0;
			OnTick?.Invoke();
		}
	}
}