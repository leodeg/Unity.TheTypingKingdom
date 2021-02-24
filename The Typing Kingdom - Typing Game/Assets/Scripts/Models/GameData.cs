[System.Serializable]
public class GameData
{
	private static GameData instance;
	private static object locker = new object();

	public static GameData Instance
	{
		set
		{
			lock (locker)
			{
				//if (value == null)
				//	instance = new SaveData();
				instance = value;
			}
		}
		get
		{
			lock (locker)
			{
				if (instance == null)
					instance = new GameData();
				return instance;
			}
		}
	}

	public PlayerProfilesContainer PlayerProfiles { get; set; } = new PlayerProfilesContainer();
}
