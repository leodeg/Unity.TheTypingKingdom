using System;
using UnityEngine;
using UnityEngine.Events;

public class EventsManager : MonoBehaviour
{
	[Header("Words Events")]
	public UnityEvent OnTypeLetterSuccess;
	public UnityEvent OnTypeLetterFailed;

	public UnityEvent OnWrittenWordWithoutErrors;
	public UnityEvent OnWrittenWordWithErrors;

	public UnityEvent OnCompleteWord;

	[Header("Targets Events")]
	public UnityEvent OnTargetCollisionWithWords;
	public UnityEvent OnTargetGetDamage;
	public UnityEvent OnTargetDeath;

	[Header("Game Events")]
	public UnityEvent OnGamePaused;
	public UnityEvent OnGameResume;
	public UnityEvent OnGameEnd;
}
