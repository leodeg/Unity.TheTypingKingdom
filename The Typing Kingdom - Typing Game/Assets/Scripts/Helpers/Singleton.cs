
[System.Serializable]
public class Singleton<T> where T : new()
{
	public static T instance { get; set; }

	private static object locker = new object();

	public static T Instance
	{
		set
		{
			lock (locker)
			{
				instance = value;
			}
		}
		get
		{
			lock (locker)
			{
				if (instance == null)
					instance = System.Activator.CreateInstance<T>();
				return instance;
			}
		}
	}
}