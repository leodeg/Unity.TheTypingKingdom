using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ParticleEffectsReferences
{
	[Header("Words")]
	public ParticleSystem typeSuccess;
	public ParticleSystem typeFailed;
	public ParticleSystem completeWord;

	[Header("Target")]
	public ParticleSystem targetDeath;
	public ParticleSystem collisionWithTarget;
}