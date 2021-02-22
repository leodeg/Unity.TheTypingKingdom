using System.Collections.Generic;
using TMPro;

public class QWERTYTextGenerator : ITextGenerator
{
	public KeyboardQWERTY Keyboard { get; set; }
	public QWERTYOptions Options { get; set; }

	private char[] _charactersArray;
	private int _minLength;
	private int _maxLength;

	public QWERTYTextGenerator(KeyboardQWERTY keyboard, QWERTYOptions options, int minLength = 5, int maxLength = 9)
	{
		Keyboard = keyboard;
		Options = options;

		_minLength = minLength;
		_maxLength = maxLength;

		AssignCharactersArray();
	}

	public void AssignCharactersArray()
	{
		AssignCharactersArray(Keyboard, Options);
	}

	public void AssignCharactersArray(KeyboardQWERTY keyboard, QWERTYOptions options)
	{
		List<char> characters = new List<char>();

		if (options.HandType == QWERTYHandType.Both)
		{
			AssignHand(keyboard.LeftHand, options, characters);
			AssignHand(keyboard.RightHand, options, characters);
		}
		else if (options.HandType == QWERTYHandType.Left)
		{
			AssignHand(keyboard.LeftHand, options, characters);
		}
		else if (options.HandType == QWERTYHandType.Right)
		{
			AssignHand(keyboard.RightHand, options, characters);
		}

		_charactersArray = characters.ToArray();
	}

	private static void AssignHand(KeyboardSections hand, QWERTYOptions options, List<char> characters)
	{
		if (options.SectionType.HasFlag(QWERTYSectionType.Up))
		{
			characters.AddRange(hand.Up);
		}

		if (options.SectionType.HasFlag(QWERTYSectionType.Middle))
		{
			characters.AddRange(hand.Middle);
		}

		if (options.SectionType.HasFlag(QWERTYSectionType.Down))
		{
			characters.AddRange(hand.Down);
		}

		if (options.SectionType.HasFlag(QWERTYSectionType.Numbers))
		{
			characters.AddRange(hand.Numbers);
		}
	}

	public string GenerateText()
	{
		return GenerateTextWithLength(UnityEngine.Random.Range(_minLength, _maxLength));
	}

	public string GenerateTextWithLength(int length)
	{
		char[] text = new char[length];

		for (int i = 0; i < length; i++)
		{
			int randomIndex = UnityEngine.Random.Range(0, _charactersArray.Length - 1);
			text[i] = _charactersArray[randomIndex];
		}

		return text.ArrayToString();
	}
}