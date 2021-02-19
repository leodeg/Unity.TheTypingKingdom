using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "KeyboardQWERTY", menuName = "ScriptableObjects/KeyboardQWERTY")]
public class KeyboardQWERTYScriptable : ScriptableObject
{
	public KeyboardSections LeftHand;
	public KeyboardSections RightHand;

	public KeyboardQWERTYScriptable(KeyboardSections left, KeyboardSections right)
	{
		LeftHand = left;
		RightHand = right;
	}
}
