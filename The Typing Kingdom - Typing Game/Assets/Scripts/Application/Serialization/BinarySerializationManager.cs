using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BinarySerializationManager
{
	public static string SavePath => Application.persistentDataPath + "/saves/";

	public static bool Save(string saveName, object data)
	{
		var formatter = GetBinaryFormatter();

		if (!Directory.Exists(SavePath))
			Directory.CreateDirectory(SavePath);

		string path = $"{SavePath}{saveName}";

		var stream = File.Create(path);
		formatter.Serialize(stream, data);
		stream.Close();

		return true;
	}

	public static object Load(string fileName)
	{
		var path = SavePath + fileName;

		if (!File.Exists(path))
			return null;

		var formatter = GetBinaryFormatter();
		var stream = File.Open(path, FileMode.Open);

		try
		{
			object data = formatter.Deserialize(stream);
			stream.Close();
			return data;
		}
		catch
		{
			Debug.LogErrorFormat("Failed to load file at {0}", path);
			stream.Close();
			return null;
		}
	}

	public static string[] GetLoadingFiles()
	{
		if (!Directory.Exists(SavePath))
			Directory.CreateDirectory(SavePath);

		return Directory.GetFiles(SavePath);
	}

	public static BinaryFormatter GetBinaryFormatter()
	{
		var formatter = new BinaryFormatter();

		// for additional formatter settings

		return formatter;
	}
}
