using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
	public string playerName;
	public PlayerProfile currenPlayerProfile;
	private const string DefaultSaveFileName = "Save.save";

	public void OnChangePlayerName(string playerName)
	{
		this.playerName = playerName;
	}

	public void CreateNewPlayer()
	{
		currenPlayerProfile = SaveData.Instance.CreateOrFindPlayerProfile(playerName);
	}

	public void GetCurrentPlayerProfile()
	{
		SaveData.Instance.TryGetPlayerProfile(playerName, out currenPlayerProfile);
	}

	public void OnSave()
	{
		BinarySerializationManager.Save(DefaultSaveFileName, SaveData.Instance);
	}

	public void OnLoad()
	{
		SaveData.Instance = BinarySerializationManager.Load(DefaultSaveFileName) as SaveData;
	}
}