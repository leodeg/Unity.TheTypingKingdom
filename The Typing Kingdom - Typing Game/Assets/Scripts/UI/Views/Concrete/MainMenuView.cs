using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : View
{
	[SerializeField] private Button buttonToHandsTrainingMode;
	[SerializeField] private Button buttonToWordsSandboxMode;
	[SerializeField] private Button buttonToStatisticsView;
	[SerializeField] private Button buttonToSettingsView;
	[SerializeField] private Button buttonToPlayerProfilesView;

	public override void Initialize()
	{
		buttonToHandsTrainingMode.onClick.AddListener(() => ViewManager.Show<HandsTrainingModeView>());
		buttonToWordsSandboxMode.onClick.AddListener(() => ViewManager.Show<WordsSandboxModeView>());
		buttonToStatisticsView.onClick.AddListener(() => ViewManager.Show<StatisticsView>());
		buttonToSettingsView.onClick.AddListener(() => ViewManager.Show<SettingsView>());
		buttonToPlayerProfilesView.onClick.AddListener(() => ViewManager.Show<PlayerProfilesView>());
	}
}
