using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable] public class StringEvent : UnityEvent<string> { }

public class PlayerProfilesUiManager : MonoBehaviour
{
	[SerializeField]
	private PlayerProfilesManager playerProfilesManager;

	[SerializeField]
	private Transform content;

	[SerializeField]
	private GameObject buttonPrefab;

	public UnityEvent OnClickProfileButton;

	private void Start()
	{
		UpdatePlayerProfileList();
	}

	public void UpdatePlayerProfileList()
	{
		content.Clear();
		Font font = Resources.GetBuiltinResource<Font>("Arial.ttf");
		foreach (var profileName in playerProfilesManager.GetListOfProfilesNames())
		{

			GameObject gameObject = Instantiate(buttonPrefab, content);
			gameObject.name = profileName + "_Button";

			Text text = gameObject.GetComponentInChildren<Text>();
			text.text = profileName;

			gameObject.GetComponent<Button>().onClick.AddListener(() => playerProfilesManager.AssignCurrentPlayerProfile(profileName));
			gameObject.GetComponent<Button>().onClick.AddListener(() => OnClickProfileButton?.Invoke());
		}
	}
}
