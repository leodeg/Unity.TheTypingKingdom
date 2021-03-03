﻿using UnityEngine;
using UnityEngine.UI;

public class StatisticsView : View
{
	[SerializeField] private Button buttonToMainMenuView;

	public override void Initialize()
	{
		buttonToMainMenuView.onClick.AddListener(() => ViewManager.Show<MainMenuView>());
	}
}
