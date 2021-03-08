using System;

[Flags]
public enum QWERTYSectionType
{
	Up = 0x00, // qwertyuiop
	Middle = 0x01, // asdfghjkl;
	Down = 0x02, // zxcvbnm,.?
	Numbers = 0x04, // 1234567890
	AllLetters = Up | Middle | Down,
	AllLettersAndNumbers = Up | Middle | Down | Numbers
}