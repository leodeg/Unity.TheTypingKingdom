using UnityEngine;
using UnityEngine.Events;

public class SceneManager : MonoBehaviour
{
	public UnityEvent OnLoadMainMenu;
	public UnityEvent OnLoadGameScene;

	public void LoadMenuScene()
	{
		OnLoadMainMenu?.Invoke();
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}

	public void LoadGameScene()
	{
		OnLoadGameScene?.Invoke();
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}
}