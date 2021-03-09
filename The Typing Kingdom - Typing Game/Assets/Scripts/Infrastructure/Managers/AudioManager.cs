using UnityEngine;

[RequireComponent(typeof(AudioPlayer))]
public class AudioManager : MonoBehaviour
{
	public bool playRandomMusic;
	public bool playOnStart;
	public AudioPlayer audioPlayer;
	public AudioReferencesScritable audioReferences;

	public static AudioManager Instance { get; private set; }

	private int currentMusicIndex;

	private void Awake()
	{
		if (audioReferences == null)
		{
			Debug.LogError("Audio references with sounds effects and music is empty. Please assign audio references!");
			return;
		}

		if (audioPlayer == null)
		{
			audioPlayer = GetComponent<AudioPlayer>();
		}

		if (Instance == null || Instance != this.gameObject)
			Instance = this.gameObject.GetComponent<AudioManager>();

		DontDestroyOnLoad(gameObject);
	}

	private void Start()
	{
		if (playOnStart)
			if (!audioPlayer.IsPlaying)
				PlayNextMusic();
	}

	private void Update()
	{
		if (!audioPlayer.IsPlaying)
		{
			if (playRandomMusic)
				PlayRandomMusic();
			else PlayNextMusic();
		}
	}

	public void AssignAudioEffectsToEventsManager(EventsManager eventsManager)
	{
		eventsManager.OnTypeLetterSuccess.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.typeSuccess));
		eventsManager.OnTypeLetterFailed.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.typeFailed));
		eventsManager.OnCompleteWord.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.completeWord));

		eventsManager.OnTargetCollisionWithWords.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.collisionWithTarget));
		eventsManager.OnTargetDeath.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.targetDeath));

		eventsManager.OnGameEnd.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.gameEnd));
		eventsManager.OnGamePaused.AddListener(() => audioPlayer.PlaySFX(audioReferences.variable.openGameMenu));
	}

	private void PlayRandomMusic()
	{
		if (audioReferences.variable.backgroundMusic.Count <= 0)
		{
			Debug.LogError("Music list is empty!");
			return;
		}

		AudioClip randomMusic = GetRandomMusic();

		if (audioReferences.variable.backgroundMusic.Count > 1)
			while (randomMusic != audioPlayer.CurrentPlayingClip)
				randomMusic = GetRandomMusic();

		audioPlayer.PlayMusic(randomMusic);
	}

	private AudioClip GetRandomMusic()
	{
		int index = UnityEngine.Random.Range(0, audioReferences.variable.backgroundMusic.Count - 1);
		return audioReferences.variable.backgroundMusic[index];
	}

	private void PlayNextMusic()
	{
		audioPlayer.PlayMusic(GetNextMusic());
	}

	private AudioClip GetNextMusic()
	{
		if (currentMusicIndex >= audioReferences.variable.backgroundMusic.Count)
			currentMusicIndex = 0;

		return audioReferences.variable.backgroundMusic[currentMusicIndex++];
	}
}

