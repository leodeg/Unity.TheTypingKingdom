using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PauseManager : MonoBehaviour
{
	public float transitionTime = 1.5f;

	public UnityEvent OnPaused;
	public UnityEvent OnResume;

	private bool isPaused = false;

	public void PauseGame()
	{
		Time.timeScale = 0;
		isPaused = true;
	}

	public void PauseGameWithFade()
	{
		StartCoroutine(PauseGameWithFade(transitionTime));
		isPaused = true;
	}

	private IEnumerator PauseGameWithFade(float transitionTime)
	{
		float transition;
		for (transition = 0.0f; transition < transitionTime; transition += Time.deltaTime)
		{
			Time.timeScale = 1 - (transition / transitionTime);
			yield return null;
		}
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
		isPaused = false;
	}

	public void ResumeGameWithFade()
	{
		StartCoroutine(ResumeGameWithFade(transitionTime));
		isPaused = false;
	}

	private IEnumerator ResumeGameWithFade(float transitionTime)
	{
		float transition;
		for (transition = 0.0f; transition < transitionTime; transition += Time.deltaTime)
		{
			Time.timeScale = transition / transitionTime;
			yield return null;
		}
	}

	public void SwitchPauseState()
	{
		Time.timeScale = isPaused ? 1 : 0;
		isPaused = !isPaused;
	}
}