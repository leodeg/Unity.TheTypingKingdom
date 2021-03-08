using UnityEngine;

public class TimeCounter : MonoBehaviour
{
	public float TimePassed { get; set; }

	private void Start()
	{
		TimePassed = 0;
	}

	private void Update()
	{
		TimePassed += Time.deltaTime;
	}
}
