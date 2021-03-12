using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
	public float min;
	public float max;
	public float current;
	public Image mask;
	public Image fill;
	public Image background;
	public Color fillColor = Color.red;
	public Color defaultColor = Color.green;

	private void Start()
	{
		fill.color = fillColor;
		background.color = defaultColor;

		UpdateProgressBar();
	}

	public void UpdateProgressBar()
	{
		UpdateProgressBar(current);
	}

	public void UpdateProgressBar(int current)
	{
		UpdateProgressBar((float)current);
	}

	public void UpdateProgressBar(float current)
	{
		this.current = current;
		mask.fillAmount = GetCurrentFill();
	}

	private float GetCurrentFill()
	{
		float currentOffset = current - min;
		float maxOffset = max - min;
		return currentOffset / maxOffset;
	}
}
