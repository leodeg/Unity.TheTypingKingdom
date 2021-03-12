using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// For more information watch video: https://www.youtube.com/watch?v=rdXC2om16lo
/// </summary>
public class ViewManager : MonoBehaviour
{
	private static ViewManager instance;

	[SerializeField] private View startingView;

	[SerializeField] private View[] views;

	private View currentView;

	private readonly Stack<View> history = new Stack<View>();

	private void Awake()
	{
		instance = this;

		if (!views.Any())
		{
			views = FindObjectsOfType<View>();

			if (views.Any() && startingView == null)
			{
				startingView = views[0];
			}
			else
			{
				Debug.LogWarning("View manager's list of views is empty!");
			}
		}
	}

	private void Start()
	{
		for (int i = 0; i < views.Length; i++)
		{
			views[i].Initialize();
			views[i].Hide();
		}

		if (startingView != null)
		{
			Show(startingView, true);
		}
	}

	public static T GetView<T>() where T : View
	{
		return instance.views.FirstOrDefault(view => view is T) as T;
	}

	public static void Hide<T>() where T : View
	{
		instance.views.FirstOrDefault(view => view is T)?.Hide();
	}

	public static void Show<T>(bool remember = true) where T : View
	{
		var view = GetView<T>();

		if (view != null)
		{
			Show(view, remember);
		}
	}

	public static void Show(View view, bool remember = true)
	{
		if (instance.currentView != null)
		{
			if (remember)
			{
				instance.history.Push(instance.currentView);
			}

			instance.currentView.Hide();
		}

		view.Show();

		instance.currentView = view;
	}

	public static void ShowLast()
	{
		if (instance.history.Count != 0)
		{
			Show(instance.history.Pop(), false);
		}
	}


}