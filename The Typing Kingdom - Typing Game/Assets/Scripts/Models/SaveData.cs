using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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
