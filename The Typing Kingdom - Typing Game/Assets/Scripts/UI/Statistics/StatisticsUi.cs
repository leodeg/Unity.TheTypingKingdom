using UnityEngine;
using UnityEngine.UI;

public class StatisticsUi : MonoBehaviour
{
	[SerializeField]
	private PlayerProfileScriptable activePlayerProfile;

	[SerializeField]
	private Transform content;

	private void Start()
	{
		UpdateStatistics();
	}

	public void UpdateStatistics()
	{
		if (activePlayerProfile == null)
		{
			Debug.LogError("Active player profile is empty!");
			return;
		}

		content.Clear();

		GameObject gameObject = new GameObject();
		gameObject.transform.SetParent(content);

		Font font = Resources.GetBuiltinResource<Font>("Arial.ttf");

		var text = gameObject.AddComponent<Text>();
		text.font = font;
		text.text = activePlayerProfile.PlayerProfile.ToString();
	}
}
