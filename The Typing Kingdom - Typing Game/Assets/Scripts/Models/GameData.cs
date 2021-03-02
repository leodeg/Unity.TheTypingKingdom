[System.Serializable]
public class GameData : Singleton<GameData>
{
	public PlayerProfilesContainer PlayerProfiles { get; set; } = new PlayerProfilesContainer();
}
