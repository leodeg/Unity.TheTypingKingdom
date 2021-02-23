using UnityEngine;

public class PauseManager : MonoBehaviour
{
	private bool isPaused = false;

	public void PauseGame()
	{
		Time.timeScale = 0;
		isPaused = true;
	}

	public void ResumeGame()
	{
		Time.timeScale = 0;
		isPaused = false;
	}

	public void SwitchPauseState()
	{
		Time.timeScale = isPaused ? 1 : 0;
		isPaused = !isPaused;
	}
}