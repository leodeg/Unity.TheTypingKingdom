public class KeyboardQWERTY
{
	public KeyboardSections LeftHand { get; }
	public KeyboardSections RightHand { get; }

	public KeyboardQWERTY(KeyboardSections left, KeyboardSections right)
	{
		LeftHand = left;
		RightHand = right;
	}
}
