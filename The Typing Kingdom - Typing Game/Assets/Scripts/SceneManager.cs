using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
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