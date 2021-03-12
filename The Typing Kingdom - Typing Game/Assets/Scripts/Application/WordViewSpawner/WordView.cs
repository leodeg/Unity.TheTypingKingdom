using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WordView : MonoBehaviour
{
	public Text word;
	public Transform target;
	[SerializeField] private float collisionDistance = 0.1f;

	public UnityEvent OnCollisionWithTarget;

	private float speed = 1f;
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
				OnCollisionWithTarget?.Invoke();
				RemoveWord();
			}
		}
	}

	public void SetSpeed(float speed)
	{
		this.speed = speed;
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
