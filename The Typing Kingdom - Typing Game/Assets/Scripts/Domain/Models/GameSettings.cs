using UnityEngine;

[System.Serializable]
public class GameSettings
{
	[Header("Game Properties")]
	[SerializeField] private GameLanguage gameLanguage;
	[SerializeField] private GameDifficulty gameDifficulty;
	[SerializeField] [Range(0.0f, 1.0f)] private float musicVolume = 1.0f;
	[SerializeField] [Range(0.0f, 1.0f)] private float sfxVolume = 1.0f;

	[Header("Spawn Properties")]
	[SerializeField] private GameType gameType;
	[SerializeField] private QWERTYHandType handType;
	[SerializeField] private QWERTYSectionType sectionTypes = QWERTYSectionType.AllLetters;

	[Header("Difficulty Speed Properties")]
	[SerializeField] private float easyGameSpeed = 0.3f;
	[SerializeField] private float mediumGameSpeed = 0.5f;
	[SerializeField] private float hardGameSpeed = 0.8f;
	[SerializeField] private float godGameSpeed = 1.4f;

	[Header("Difficulty Damage Properties")]
	[SerializeField] private int easyGameDamage = 10;
	[SerializeField] private int mediumGameDamage = 20;
	[SerializeField] private int hardGameDamage = 30;
	[SerializeField] private int godGameDamage = 40;

	[Header("Difficulty Enemy Spawns Properties")]
	[SerializeField] private int secondsBetweenSpawns = 2;

	[Header("Target Properties")]
	[SerializeField] private int defaultHitPointsAmount = 100;

	[Header("Spawn Words Properties")]
	[SerializeField] private int minWordLength = 4;
	[SerializeField] private int maxWordLength = 8;

	public float GetSpeedByGameDifficulty()
	{
		switch (GameDifficulty)
		{
			case GameDifficulty.Easy: return EasyGameSpeed;
			case GameDifficulty.Medium: return MediumGameSpeed;
			case GameDifficulty.Hard: return HardGameSpeed;
			case GameDifficulty.God: return GodGameSpeed;
			default: return EasyGameSpeed;
		}
	}

	public int GetDamageByGameDifficulty()
	{
		switch (GameDifficulty)
		{
			case GameDifficulty.Easy: return EasyGameDamage;
			case GameDifficulty.Medium: return MediumGameDamage;
			case GameDifficulty.Hard: return HardGameDamage;
			case GameDifficulty.God: return GodGameDamage;
			default: return EasyGameDamage;
		}
	}

	public GameLanguage GameLanguage { get => gameLanguage; set => gameLanguage = value; }
	public GameDifficulty GameDifficulty { get => gameDifficulty; set => gameDifficulty = value; }
	public GameType GameType { get => gameType; set => gameType = value; }
	public QWERTYHandType HandType { get => handType; set => handType = value; }
	public QWERTYSectionType SectionTypes { get => sectionTypes; set => sectionTypes = value; }

	public int EasyGameDamage { get => easyGameDamage; set => easyGameDamage = value; }
	public int MediumGameDamage { get => mediumGameDamage; set => mediumGameDamage = value; }
	public int HardGameDamage { get => hardGameDamage; set => hardGameDamage = value; }
	public int GodGameDamage { get => godGameDamage; set => godGameDamage = value; }

	public float EasyGameSpeed { get => easyGameSpeed; set => easyGameSpeed = value; }
	public float MediumGameSpeed { get => mediumGameSpeed; set => mediumGameSpeed = value; }
	public float HardGameSpeed { get => hardGameSpeed; set => hardGameSpeed = value; }
	public float GodGameSpeed { get => godGameSpeed; set => godGameSpeed = value; }

	public int SecondsBetweenSpawns { get => secondsBetweenSpawns; set => secondsBetweenSpawns = value; }

	public int MinWordLength { get => minWordLength; set => minWordLength = value; }
	public int MaxWordLength { get => maxWordLength; set => maxWordLength = value; }
	public int DefaultHitPointsAmount { get => defaultHitPointsAmount; set => defaultHitPointsAmount = value; }
	public float MusicVolume { get => musicVolume; set => musicVolume = value; }
	public float SfxVolume { get => sfxVolume; set => sfxVolume = value; }
}