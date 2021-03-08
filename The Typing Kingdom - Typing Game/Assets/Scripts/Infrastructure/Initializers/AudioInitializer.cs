using UnityEngine;

public class AudioInitializer : MonoBehaviour
{
	public AudioReferencesScritable audioReferences;
	public AudioPlayerManager audioPlayer;
	public EventsManager eventsManager;

	private void Awake()
	{
		audioPlayer = AudioPlayerManager.Instance;

		eventsManager.OnTypeLetterSuccess.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.typeSuccess));
		eventsManager.OnTypeLetterFailed.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.typeFailed));
		eventsManager.OnCompleteWord.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.completeWord));

		eventsManager.OnTargetCollisionWithWords.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.collisionWithTarget));
		eventsManager.OnTargetDeath.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.targetDeath));

		eventsManager.OnGameEnd.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.gameEnd));
		eventsManager.OnGamePaused.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.openGameMenu));
	}
}