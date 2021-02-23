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
		dropdownGameDifficulty.SetDefaultIndex(gameSettingsScritable.settings.GameDifficulty.ToString());
		dropdownGameLanguage.SetDefaultIndex(gameSettingsScritable.settings.GameLanguage.ToString());
		dropdownQWERTYHandType.SetDefaultIndex(gameSettingsScritable.settings.HandType.ToString());
		dropdownQWERTYSectionType.SetDefaultIndex(gameSettingsScritable.settings.SectionTypes.ToString());
		minWordsLength.text = gameSettingsScritable.settings.MinWordLength.ToString();
		maxWordsLength.text = gameSettingsScritable.settings.MaxWordLength.ToString();
	}
}