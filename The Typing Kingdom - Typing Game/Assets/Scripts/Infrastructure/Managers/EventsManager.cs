using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventTransform : UnityEvent<Transform> { }

public class EventsManager : MonoBehaviour
{
	[Header("Words Events with returning transform")]
	// Events for VFX effects
	public UnityEventTransform OnTypeLetterSuccessReturnTransform = new UnityEventTransform();
	public UnityEventTransform OnTypeLetterFailedReturnTransform = new UnityEventTransform();
	public UnityEventTransform OnCompleteWordReturnTransform = new UnityEventTransform();

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
