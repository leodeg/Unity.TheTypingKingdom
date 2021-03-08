using UnityEngine;
using UnityEngine.UI;

public class HandsTrainingModeView : View
{
	[SerializeField] private Button buttonToMainMenuView;

	public override void Initialize()
	{
		buttonToMainMenuView.onClick.AddListener(() => ViewManager.Show<MainMenuView>());
	}
}
