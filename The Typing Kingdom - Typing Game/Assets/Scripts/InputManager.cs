using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
	public WordsController WordsController { get; set; }

	void Update()
	{
		foreach (char input in Input.inputString)
		{
			WordsController.ProcessInput(input);
		}
	}
}
