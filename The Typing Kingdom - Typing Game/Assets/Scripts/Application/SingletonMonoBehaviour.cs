
using UnityEngine;

[System.Serializable]
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;
	private static readonly object instanceLock = new object();
	private static bool quitting = false;

	public static T Instance
	{
		get
		{
			lock (instanceLock)
			{
				if (instance == null && !quitting)
				{

					instance = FindObjectOfType<T>();
					if (instance == null)
					{
						GameObject go = new GameObject($"Spawned__{typeof(T).ToString()}");
						instance = go.AddComponent<T>();

						DontDestroyOnLoad(instance.gameObject);
					}
				}

				return instance;
			}
		}
	}

	protected virtual void OnApplicationQuit()
	{
		quitting = true;
	}
}