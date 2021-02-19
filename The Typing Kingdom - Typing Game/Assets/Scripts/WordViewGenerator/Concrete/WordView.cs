using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordView : MonoBehaviour
{
	public event Action OnCollisionWithTarget;

	public Text word;
	public Transform target;

	public float speed = 1f;
	public float collisionDistance = 0.01f;

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

	private void MoveToTarget()
	{
		float step = speed * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position, target.position, step);

		if (Vector3.Distance(transform.position, target.position) < 0.01f)
			OnCollisionWithTarget?.Invoke();
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
