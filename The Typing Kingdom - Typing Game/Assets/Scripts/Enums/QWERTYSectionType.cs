using System;

[Flags]
public enum QWERTYSectionType
{
	Up = 0x00,
	Middle = 0x01,
	Down = 0x02,
	Numbers = 0x04,
	AllLetters = Up | Middle | Down,
	AllLettersAndNumbers = Up | Middle | Down | Numbers
}