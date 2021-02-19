using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings")]
public class GameSettingsScritable : ScriptableObject
{
	[Header("Game Properties")]
	public GameLanguage gameLanguage;
	public GameDifficulty gameDifficulty;

	[Header("Spawn Properties")]
	public GameType gameType;
	public HandType handType;
	public QWERTYSectionType sectionTypes = QWERTYSectionType.AllLetters;

	[Header("Difficulty Properties")]
	public float easyGameSpeed = 0.3f;
	public float mediumGameSpeed = 0.5f;
	public float hardGameSpeed = 0.8f;
	public float godGameSpeed = 1.4f;

	[Header("Spawn Words Properties")]
	public int minWordLength = 4;
	public int maxWordLength = 8;

}
