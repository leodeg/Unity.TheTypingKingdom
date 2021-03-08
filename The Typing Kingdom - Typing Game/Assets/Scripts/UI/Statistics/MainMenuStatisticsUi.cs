using UnityEngine;
using UnityEngine.UI;

public class MainMenuStatisticsUi : MonoBehaviour
{
	[SerializeField]
	private PlayerProfilesManager playerProfiles;

	[SerializeField]
	private Transform content;

	private void Start()
	{
		UpdateStatistics();
	}

	public void UpdateStatistics()
	{
		if (playerProfiles == null)
		{
			Debug.LogError("Player profiles manager is empty!");
			return;
		}

		content.Clear();

		GameObject gameObject = new GameObject();
		gameObject.transform.SetParent(content);

		Font font = Resources.GetBuiltinResource<Font>("Arial.ttf");

		var text = gameObject.AddComponent<Text>();
		text.font = font;
		text.text = playerProfiles.ToString();
	}
}
