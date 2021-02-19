using UnityEngine;

public class InputController : MonoBehaviour
{
	[SerializeField]
	public WordsController WordController { get; set; }

	void Update()
	{
		foreach (char input in Input.inputString)
		{
			WordController.ProcessInput(input);
		}
	}
}