using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyboardSections
{
	public char[] Up; // qwertyuiop
	public char[] Middle; // asdfghjkl;
	public char[] Down; // zxcvbnm,.?
	public char[] Numbers; // 1234567890

	public KeyboardSections(char[] up, char[] middle, char[] down, char[] numbers)
	{
		Up = up;
		Middle = middle;
		Down = down;
		Numbers = numbers;
	}

	//TODO: Get random characters from up, middle, down and numbers
}
