using UnityEngine;

public class GameDataManager : MonoBehaviour
{
	private const string DefaultSaveFileName = "Save.save";

	public void SaveGameData()
	{
		BinarySerializationManager.Save(DefaultSaveFileName, SaveData.Instance);
	}

	public void LoadGameData()
	{
		SaveData.Instance = BinarySerializationManager.Load(DefaultSaveFileName) as SaveData;
	}
}