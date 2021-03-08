using UnityEngine;
using UnityEngine.UI;

public class GamePauseView : View
{
	[SerializeField] private Button buttonToCloseCurrentView;

	public override void Initialize()
	{
		buttonToCloseCurrentView.onClick.AddListener(() => ViewManager.Hide<GamePauseView>());
	}
}
