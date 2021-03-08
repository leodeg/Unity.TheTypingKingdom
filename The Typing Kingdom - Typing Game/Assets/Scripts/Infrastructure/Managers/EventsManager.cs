using UnityEngine;
using UnityEngine.Events;

public class UnityEventTransform : UnityEvent<Transform> { }

public class EventsManager : SingletonMonoBehaviour<EventsManager>
{
	[Header("Words Events with returning transform")]
	// Events for VFX effects
	public UnityEventTransform OnTypeLetterSuccessReturnTransform;
	public UnityEventTransform OnTypeLetterFailedReturnTransform;
	public UnityEventTransform OnCompleteWordReturnTransform;

	[Header("Words Events")]
	public UnityEvent OnTypeLetterSuccess;
	public UnityEvent OnTypeLetterFailed;
	public UnityEvent OnWrittenWordWithoutErrors;
	public UnityEvent OnWrittenWordWithErrors;
	public UnityEvent OnCompleteWord;

	[Header("Targets Events")]
	public UnityEvent OnTargetCollisionWithWords;
	public UnityEvent OnTargetDeath;

	[Header("Game Events")]
	public UnityEvent OnGamePaused;
	public UnityEvent OnGameResume;
	public UnityEvent OnGameEnd;
}
