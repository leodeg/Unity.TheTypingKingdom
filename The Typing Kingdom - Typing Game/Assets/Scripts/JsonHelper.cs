using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;

public static class JsonHelper
{
	public static T ReadFromAsset<T>(string json)
	{
		return JsonConvert.DeserializeObject<T>(json);
	}
}
