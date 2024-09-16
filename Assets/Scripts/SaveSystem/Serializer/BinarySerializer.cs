using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SaveSystem.Serializer
{
public static class BinarySerializer
{
	public static byte[] Serialize<T>(T data)
	{
		string jsonString = JsonConvert.SerializeObject(data,
		                                                new JsonSerializerSettings
		                                                {
			                                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
		                                                });
		return System.Text.Encoding.UTF8.GetBytes(jsonString);
	}

	public static T Deserialize<T>(byte[] byteData)
	{
		string jsonString = System.Text.Encoding.UTF8.GetString(byteData);
		return JsonConvert.DeserializeObject<T>(jsonString);
	}

	public static byte[] SerializeDictionary(Dictionary<string, byte[]> dictionary)
	{
		using var ms     = new MemoryStream();
		using var writer = new BinaryWriter(ms);

		writer.Write(dictionary.Count);
		foreach (var kvp in dictionary)
		{
			writer.Write(kvp.Key);
			writer.Write(kvp.Value.Length);
			writer.Write(kvp.Value);
		}

		return ms.ToArray();
	}

	public static Dictionary<string, byte[]> DeserializeDictionary(byte[] bytes)
	{
		using var ms         = new MemoryStream(bytes);
		using var reader     = new BinaryReader(ms);
		int       count      = reader.ReadInt32();
		var       dictionary = new Dictionary<string, byte[]>();

		for (var i = 0; i < count; i++)
		{
			string key    = reader.ReadString();
			int    length = reader.ReadInt32();
			byte[] value  = reader.ReadBytes(length);
			dictionary[key] = value;
		}

		return dictionary;
	}

	public static string ToBase64(byte[] bytes)
	{
		return Convert.ToBase64String(bytes);
	}

	public static byte[] FromBase64(string base64String)
	{
		return Convert.FromBase64String(base64String);
	}
}
}