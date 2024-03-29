﻿
using UnityEngine;

[System.Serializable]
public class Singleton<T> where T : new()
{
	private static T instance;

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
