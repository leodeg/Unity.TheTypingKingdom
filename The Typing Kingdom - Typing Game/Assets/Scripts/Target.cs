using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
	[SerializeField]
	private int hitPoints = 100;

	public UnityEvent OnTargetDeath;

	public int HitPoints { get => hitPoints; set => hitPoints = value; }
	public bool IsTargetDead => hitPoints <= 0;

	public int CurrentDamage { get; set; }

	public void AddDamage()
	{
		AddDamage(CurrentDamage);
	}

	public void AddDamage(int damage)
	{
		if (damage > 0)
		{
			hitPoints -= damage;
			if (IsTargetDead)
				OnTargetDeath?.Invoke();
		}
	}
}