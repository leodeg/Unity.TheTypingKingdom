[System.Serializable]
public class GameData : Singleton<GameData>
{
	//public static GameData instance { get; set; }

	//private static object locker = new object();

	//public static GameData Instance
	//{
	//	set
	//	{
	//		lock (locker)
	//		{
	//			instance = value;
	//		}
	//	}
	//	get
	//	{
	//		lock (locker)
	//		{
	//			if (instance == null)
	//				instance = new GameData();
	//			return instance;
	//		}
	//	}
	//}

	public PlayerProfilesContainer PlayerProfiles { get; set; } = new PlayerProfilesContainer();
}
