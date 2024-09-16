using System.Collections.Generic;
using UnityEngine;
using SaveSystem.Serializer;

namespace SaveSystem.Repository
{
public class GameRepository : IGameRepository
{
	private const string GAME_STATE_KEY = "GameStateKey";

	private Dictionary<string, byte[]> _gameState = new();

	public void SetData<T>(T data)
	{
		var key = typeof(T).ToString();
		_gameState[key] = BinarySerializer.Serialize(data);
	}

	public bool TryGetData<T>(out T data)
	{
		var key = typeof(T).ToString();

		if (_gameState.TryGetValue(key, out byte[] byteData))
		{
			data = BinarySerializer.Deserialize<T>(byteData);
			return true;
		}

		data = default;
		return false;
	}

	public void LoadState()
	{
		if (PlayerPrefs.HasKey(GAME_STATE_KEY))
		{
			string base64String = PlayerPrefs.GetString(GAME_STATE_KEY);
			byte[] bytes        = BinarySerializer.FromBase64(base64String);
			
			_gameState = BinarySerializer.DeserializeDictionary(bytes);
		}
		else
		{
			Debug.Log("No save!");
		}
	}

	public void SaveState()
	{
		byte[] bytes        = BinarySerializer.SerializeDictionary(_gameState);
		string base64String = BinarySerializer.ToBase64(bytes);
		PlayerPrefs.SetString(GAME_STATE_KEY, base64String);
	}
}
}