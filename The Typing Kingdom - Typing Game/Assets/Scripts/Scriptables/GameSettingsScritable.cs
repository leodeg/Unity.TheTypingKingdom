using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettingsScritable : ScriptableObject
{
	public GameSettings settings;

	public void SetHandTrainingMode ()
	{
		settings.GameType = GameType.HandsTraining;
	}

	public void SetWordsSandboxMode()
	{
		settings.GameType = GameType.WordsSandbox;
	}

	public void AssignMinLength(TMP_InputField inputField)
	{
		settings.MinWordLength = Convert.ToInt32(inputField.text);
	}

	public void AssignMaxLength(TMP_InputField inputField)
	{
		settings.MaxWordLength = Convert.ToInt32(inputField.text);
	}

	public void AssignHandTypes(QWERTYHandType handType)
	{
		settings.HandType = handType;
	}

	public void AssignSectionType(QWERTYSectionType sectionType)
	{
		settings.SectionTypes = sectionType;
	}

	public void AssignGameDifficulty(GameDifficulty gameDifficulty)
	{
		settings.GameDifficulty = gameDifficulty;
	}

	public void AssignGameLanguage(GameLanguage gameLanguage)
	{
		settings.GameLanguage = gameLanguage;
	}
}
