using UnityEngine;

public class Windows : MonoBehaviour
{
	public void Show()
	{
		this.gameObject.SetActive(true);
	}

	public void Hide()
	{
		this.gameObject.SetActive(false);
	}
}