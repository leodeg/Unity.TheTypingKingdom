using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
	public UnityEvent OnEscapeDown;

	public WordsController WordsController { get; set; }

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			OnEscapeDown?.Invoke();
		}

		foreach (char input in Input.inputString)
		{
			WordsController.ProcessInput(input);
		}
	}
}
