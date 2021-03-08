using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioReferences
{
	[Header("Typing")]
	public AudioClip typeSuccess;
	public AudioClip typeFailed;
	public AudioClip completeWord;

	[Header("Target")]
	public AudioClip targetDeath;
	public AudioClip collisionWithTarget;

	[Header("Game Menu")]
	public AudioClip openGameMenu;
	public AudioClip gameEnd;

	[Header("Background Music")]
	public List<AudioClip> backgroundMusic;
}