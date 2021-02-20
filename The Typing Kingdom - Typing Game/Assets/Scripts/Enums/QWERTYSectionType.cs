using System;

[Flags]
public enum QWERTYSectionType
{
	Up,
	Middle,
	Down,
	Numbers,
	AllLetters = Up | Middle | Down,
	AllLettersAndNumbers = Up | Middle | Down | Numbers
}