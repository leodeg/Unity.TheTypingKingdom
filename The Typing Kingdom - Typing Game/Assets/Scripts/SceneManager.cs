using UnityEngine;
using UnityEngine.Events;

public class SceneManager : MonoBehaviour
{
	public UnityEvent OnLoadMainMenu;
	public UnityEvent OnLoadGameScene;

	private void Awake()
	{
		DontDestroyOnLoad(this);
	}

	public void LoadMenuScene()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
	}

	public void LoadGameScene()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
	}
}