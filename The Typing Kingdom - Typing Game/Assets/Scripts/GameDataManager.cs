using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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