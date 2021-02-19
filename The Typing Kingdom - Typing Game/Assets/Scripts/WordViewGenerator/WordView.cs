using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class WordView : MonoBehaviour
{
	public Text word;
	public float speed = 1f;
	public Transform target;

	private void Start()
	{
		word = GetComponent<Text>();
	}

	public void SetText (string text)
	{
		word.text = text;
	}

	public void UpdateText(string text)
	{
		word.text = text;
		word.color = Color.red;
	}

	public void RemoveWord()
	{
		Destroy(gameObject);
	}

	private void Update()
	{
		float step = speed * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position, target.position, step);

		//if (Vector3.Distance(transform.position, target.position) < 0.01f)
		//{

		//}
	}
}
