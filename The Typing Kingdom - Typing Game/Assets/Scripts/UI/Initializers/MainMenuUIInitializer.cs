using TMPro;
using UnityEngine;


public class MainMenuUIInitializer : MonoBehaviour
{
	[SerializeField] private DropdownGameDifficulty dropdownGameDifficulty;
	[SerializeField] private DropdownGameLanguage dropdownGameLanguage;
	[SerializeField] private DropdownQWERTYHandType dropdownQWERTYHandType;
	[SerializeField] private DropdownQWERTYSectionType dropdownQWERTYSectionType;
	[SerializeField] private TMP_InputField minWordsLength;
	[SerializeField] private TMP_InputField maxWordsLength;

	[SerializeField] private GameSettingsScritable gameSettingsScritable;

	private void Start()
	{
		dropdownGameDifficulty.SetDefaultIndex(gameSettingsScritable.variable.GameDifficulty.ToString());
		dropdownGameLanguage.SetDefaultIndex(gameSettingsScritable.variable.GameLanguage.ToString());
		dropdownQWERTYHandType.SetDefaultIndex(gameSettingsScritable.variable.HandType.ToString());
		dropdownQWERTYSectionType.SetDefaultIndex(gameSettingsScritable.variable.SectionTypes.ToString());
		minWordsLength.text = gameSettingsScritable.variable.MinWordLength.ToString();
		maxWordsLength.text = gameSettingsScritable.variable.MaxWordLength.ToString();
	}
}