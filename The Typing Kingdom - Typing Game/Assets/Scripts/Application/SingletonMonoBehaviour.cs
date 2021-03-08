
using UnityEngine;

[System.Serializable]
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : Object
{
	private static T instance;

	private static object locker = new object();

	public static T Instance
	{
		protected set
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
				{
					instance = FindObjectOfType<T>();

					if (instance == null)
					{
						instance = new GameObject($"Spawned_{typeof(T).Name}", typeof(T)).GetComponent<T>();
					}
				}

				return instance;
			}
		}
	}
}