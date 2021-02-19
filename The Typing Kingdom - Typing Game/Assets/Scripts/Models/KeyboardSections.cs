using System.Collections.Generic;

public class KeyboardSections
{
	public char[] Up { get; } // qwertyuiop
	public char[] Middle { get; } // asdfghjkl;
	public char[] Down { get; }  // zxcvbnm,.?
	public char[] Numbers { get; } // 1234567890

	public KeyboardSections(char[] up, char[] middle, char[] down, char[] numbers)
	{
		Up = up;
		Middle = middle;
		Down = down;
		Numbers = numbers;
	}

	//TODO: Get random characters from up, middle, down and numbers
}
