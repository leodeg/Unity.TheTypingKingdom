[System.Serializable]
public class KeyboardQWERTY
{
	public KeyboardSections LeftHand;
	public KeyboardSections RightHand;

	public KeyboardQWERTY(KeyboardSections left, KeyboardSections right)
	{
		LeftHand = left;
		RightHand = right;
	}
}
