using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WordView : MonoBehaviour
{
	public event Action<int> OnCollisionWithDamageReturn;
	public event Action<Word> OnCollisionWithWordReturn;
	public UnityEvent OnCollisionWithTarget;

	public Text word;
	public Transform target;
	public Word currentWord;

	[SerializeField]
	private float collisionDistance = 0.1f;

	private float speed = 1f;
	private int damage = 10;
	private bool isDamageAssign = false;

	private void Start()
	{
		if (target == null)
			Debug.LogError("Target is null. Please assign target!");

		if (word == null)
			word = GetComponent<Text>();
	}

	private void Update()
	{
		MoveToTarget();
	}

	public void SetSpeed(float speed)
	{
		this.speed = speed;
	}

	public void SetDamage(int damage)
	{
		this.damage = damage;
	}

	private void MoveToTarget()
	{
		float step = speed * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position, target.position, step);

		if (Vector2.Distance(transform.position, target.position) < collisionDistance)
		{
			if (!isDamageAssign)
			{
				isDamageAssign = true;
				Debug.Log("Invoke damage");
				OnCollisionWithDamageReturn?.Invoke(damage);
				OnCollisionWithTarget?.Invoke();
				OnCollisionWithWordReturn?.Invoke(currentWord);
				RemoveWord();
			}
		}
	}

	public void SetText(string text)
	{
		word.text = text;
	}

	public void UpdateText(string updatedText)
	{
		word.text = updatedText;
		word.color = Color.red;
	}

	public void RemoveWord()
	{
		Destroy(gameObject);
	}
}
