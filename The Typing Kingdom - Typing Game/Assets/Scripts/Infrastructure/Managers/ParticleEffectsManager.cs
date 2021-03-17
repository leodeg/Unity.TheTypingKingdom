using UnityEngine;
using UnityEngine.Events;

class ParticleEffectsManager : MonoBehaviour
{
	[SerializeField] private ParticleEffectsReferencesScritable particleEffects;

	private void Awake()
	{
		if (particleEffects.variable.typeSuccess == null)
			Debug.LogError("Particle effect for [type sucess] is empty!");

		if (particleEffects.variable.typeFailed == null)
			Debug.LogError("Particle effect for [type failed] is empty!");

		if (particleEffects.variable.completeWord == null)
			Debug.LogError("Particle effect for [complete word] is empty!");

		if (particleEffects.variable.collisionWithTarget == null)
			Debug.LogError("Particle effect for [collision with target] is empty!");

		if (particleEffects.variable.targetDeath == null)
			Debug.LogError("Particle effect for [target death] is empty!");
	}

	public static void PlayEffectAt(ParticleSystem effect, Vector3 position)
	{
		var particle = Instantiate(effect.gameObject, position, Quaternion.identity);
		float time = effect.main.duration;
		Destroy(particle, time);
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