using Newtonsoft.Json;

public static class JsonSerializationManager
{
	public static T ReadFromAsset<T>(string json)
	{
		return JsonConvert.DeserializeObject<T>(json);
	}
}
