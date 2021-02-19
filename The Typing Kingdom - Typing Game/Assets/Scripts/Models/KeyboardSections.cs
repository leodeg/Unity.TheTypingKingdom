using System.Collections.Generic;

public class KeyboardSections
{
	public ICollection<char> Up { get; } // qwertyuiop
	public ICollection<char> Middle { get; } // asdfghjkl;
	public ICollection<char> Down { get; }  // zxcvbnm,.?
	public ICollection<char> Numbers { get; } // 1234567890

	public KeyboardSections(ICollection<char> up,
		ICollection<char> middle,
		ICollection<char> down,
		ICollection<char> numbers)
	{
		Up = up;
		Middle = middle;
		Down = down;
		Numbers = numbers;
	}

	//TODO: Get random characters from up, middle, down and numbers
}
