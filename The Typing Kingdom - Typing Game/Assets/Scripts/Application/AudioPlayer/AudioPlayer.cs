using System.Collections;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
	public AudioSource musicSource;
	public AudioSource musicSource2;
	public AudioSource sfxSource;

	private bool firstMusicSourceIsPlaying = false;

	private void Awake()
	{
		musicSource = gameObject.AddComponent<AudioSource>();
		musicSource2 = gameObject.AddComponent<AudioSource>();
		sfxSource = gameObject.AddComponent<AudioSource>();

		musicSource.loop = true;
		musicSource2.loop = true;
	}

	public bool IsPlaying => GetActiveSource().isPlaying;
	public AudioClip CurrentPlayingClip => GetActiveSource().clip;

	public AudioSource GetActiveSource()
	{
		return firstMusicSourceIsPlaying ? musicSource : musicSource2;
	}

	public AudioSource GetNotActiveSource()
	{
		return firstMusicSourceIsPlaying ? musicSource2 : musicSource;
	}

	public void SetMusicVolume(float volume)
	{
		musicSource.volume = volume;
		musicSource2.volume = volume;
	}

	public void SetSFXVolume(float volume)
	{
		sfxSource.volume = volume;
	}

	public void PlaySFX(AudioClip sfxClip)
	{
		sfxSource.PlayOneShot(sfxClip);
	}

	public void PlaySFX(AudioClip sfxClip, float volume)
	{
		sfxSource.PlayOneShot(sfxClip, volume);
	}

	public void PlayMusic(AudioClip musicClip)
	{
		AudioSource activeSource = GetActiveSource();

		activeSource.clip = musicClip;
		activeSource.volume = 1;
		activeSource.Play();
	}

	public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1.0f)
	{
		AudioSource activeSource = GetActiveSource();
		StartCoroutine(UpdateMusicWithFade(activeSource, newClip, transitionTime));
	}

	private IEnumerator UpdateMusicWithFade(AudioSource activeSource, AudioClip newClip, float transitionTime)
	{
		if (!activeSource.isPlaying)
		{
			activeSource.Play();
		}

		float transition = 0.0f;

		// Fade out
		for (transition = 0.0f; transition < transitionTime; transition += Time.deltaTime)
		{
			activeSource.volume = 1 - (transition / transitionTime);
			yield return null;
		}

		// Play
		activeSource.Stop();
		activeSource.clip = newClip;
		activeSource.Play();

		// Fade in
		for (transition = 0.0f; transition < transitionTime; transition += Time.deltaTime)
		{
			activeSource.volume = transition / transitionTime;
			yield return null;
		}
	}

	public void PlayMusicWithCrossFade(AudioClip newClip, float transitionTime)
	{
		AudioSource activeSource = GetActiveSource();
		AudioSource newSource = GetNotActiveSource();

		firstMusicSourceIsPlaying = !firstMusicSourceIsPlaying;

		newSource.clip = newClip;
		newSource.Play();

		StartCoroutine(UpdateMusicWithCrossFade(activeSource, newSource, transitionTime));
	}

	private IEnumerator UpdateMusicWithCrossFade(AudioSource original, AudioSource newSource, float transitionTime)
	{
		float transition = 0.0f;

		for (transition = 0.0f; transition < transitionTime; transition += Time.deltaTime)
		{
			float value = transition / transitionTime;

			original.volume = 1 - value;
			newSource.volume = value;

			yield return null;
		}

		original.Stop();
	}
}