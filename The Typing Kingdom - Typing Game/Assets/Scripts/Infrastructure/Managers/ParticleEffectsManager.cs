using UnityEngine;
using UnityEngine.Events;

class ParticleEffectsManager : MonoBehaviour
{
	public ParticleEffectsReferencesScritable particleEffects;

	public static void PlayEffectAt(ParticleSystem effect, Vector3 position)
	{
		Destroy(Instantiate(effect.gameObject, position, Quaternion.identity), effect.main.startLifetime.constantMax);
	}

	public void PlayTypeSuccess(Transform transform)
	{
		var effect = particleEffects.variable.typeSuccess;
		PlayEffectAt(effect, transform.position);
	}

	public void PlayTypeFailed(Transform transform)
	{
		var effect = particleEffects.variable.typeFailed;
		PlayEffectAt(effect, transform.position);
	}

	public void PlayCompleteWord(Transform transform)
	{
		var effect = particleEffects.variable.completeWord;
		PlayEffectAt(effect, transform.position);
	}

	public void PlayCollisionWithTarget(Transform transform)
	{
		var effect = particleEffects.variable.collisionWithTarget;
		PlayEffectAt(effect, transform.position);
	}

	public void PlayTargetDeath(Transform transform)
	{
		var effect = particleEffects.variable.targetDeath;
		PlayEffectAt(effect, transform.position);
	}
}