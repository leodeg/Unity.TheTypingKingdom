using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
	public ScriptableInteger hitPoints;

	public UnityEvent OnTargetDeath;

	public bool IsTargetDead => hitPoints.variable <= 0;
	public int CurrentDamage { get; set; }

	private void Awake()
	{
		if (hitPoints == null)
			Debug.LogError("Hit points scriptable variable not assigned!");
	}

	public void AddDamage()
	{
		AddDamage(CurrentDamage);
	}

	public void AddDamage(int damage)
	{
		if (damage > 0)
		{
			hitPoints.Set(hitPoints.variable - damage);
			if (IsTargetDead)
				OnTargetDeath?.Invoke();
		}
	}
}
