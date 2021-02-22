[System.Serializable]
public class SaveData
{
	private static SaveData instance;
	private static object locker = new object();

	public static SaveData Instance
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
					instance = new SaveData();
				return instance;
			}
		}
	}

	public PlayerProfilesContainer PlayerProfiles { get; set; } = new PlayerProfilesContainer();
}
