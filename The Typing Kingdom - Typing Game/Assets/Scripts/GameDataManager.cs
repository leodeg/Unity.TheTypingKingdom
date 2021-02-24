using UnityEngine;

public class GameDataManager : MonoBehaviour
{
	private const string DefaultSaveFileName = "Save.save";

	public void SaveGameData()
	{
		BinarySerializationManager.Save(DefaultSaveFileName, GameData.Instance);
	}

	public void LoadGameData()
	{
		GameData.Instance = BinarySerializationManager.Load(DefaultSaveFileName) as GameData;
	}
}