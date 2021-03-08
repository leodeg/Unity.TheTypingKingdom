using UnityEngine;
using UnityEngine.UI;

public class WordsSandboxModeView : View
{
	[SerializeField] private Button buttonToMainMenuView;

	public override void Initialize()
	{
		buttonToMainMenuView.onClick.AddListener(() => ViewManager.Show<MainMenuView>());
	}
}