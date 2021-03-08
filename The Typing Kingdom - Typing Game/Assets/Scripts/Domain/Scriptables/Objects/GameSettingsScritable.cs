using System;
using TMPro;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "ScriptableObjects/GameSettings")]
public class GameSettingsScritable : ScriptableVariable<GameSettings>
{
	public void SetHandTrainingMode()
	{
		variable.GameType = GameType.HandsTraining;
	}

	public void SetWordsSandboxMode()
	{
		variable.GameType = GameType.WordsSandbox;
	}

	public void AssignMinLength(TMP_InputField inputField)
	{
		variable.MinWordLength = Convert.ToInt32(inputField.text);
	}

	public void AssignMaxLength(TMP_InputField inputField)
	{
		variable.MaxWordLength = Convert.ToInt32(inputField.text);
	}

	public void AssignHandTypes(QWERTYHandType handType)
	{
		variable.HandType = handType;
	}

	public void AssignSectionType(QWERTYSectionType sectionType)
	{
		variable.SectionTypes = sectionType;
	}

	public void AssignGameDifficulty(GameDifficulty gameDifficulty)
	{
		variable.GameDifficulty = gameDifficulty;
	}

	public void AssignGameLanguage(GameLanguage gameLanguage)
	{
		variable.GameLanguage = gameLanguage;
	}
}
