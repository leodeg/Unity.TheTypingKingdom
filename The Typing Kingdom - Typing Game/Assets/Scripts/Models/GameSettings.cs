using UnityEngine;

[System.Serializable]
public class GameSettings
{
	[Header("Game Properties")]
	[SerializeField] private GameLanguage gameLanguage;
	[SerializeField] private GameDifficulty gameDifficulty;

	[Header("Spawn Properties")]
	[SerializeField] private GameType gameType;
	[SerializeField] private QWERTYHandType handType;
	[SerializeField] private QWERTYSectionType sectionTypes = QWERTYSectionType.AllLetters;

	[Header("Difficulty Properties")]
	[SerializeField] private float easyGameSpeed = 0.3f;
	[SerializeField] private float mediumGameSpeed = 0.5f;
	[SerializeField] private float hardGameSpeed = 0.8f;
	[SerializeField] private float godGameSpeed = 1.4f;

	[Header("Spawn Words Properties")]
	[SerializeField] private int minWordLength = 4;
	[SerializeField] private int maxWordLength = 8;

	public GameLanguage GameLanguage { get => gameLanguage; set => gameLanguage = value; }
	public GameDifficulty GameDifficulty { get => gameDifficulty; set => gameDifficulty = value; }
	public GameType GameType { get => gameType; set => gameType = value; }
	public QWERTYHandType HandType { get => handType; set => handType = value; }
	public QWERTYSectionType SectionTypes { get => sectionTypes; set => sectionTypes = value; }
	public float EasyGameSpeed { get => easyGameSpeed; set => easyGameSpeed = value; }
	public float MediumGameSpeed { get => mediumGameSpeed; set => mediumGameSpeed = value; }
	public float HardGameSpeed { get => hardGameSpeed; set => hardGameSpeed = value; }
	public float GodGameSpeed { get => godGameSpeed; set => godGameSpeed = value; }
	public int MinWordLength { get => minWordLength; set => minWordLength = value; }
	public int MaxWordLength { get => maxWordLength; set => maxWordLength = value; }
}