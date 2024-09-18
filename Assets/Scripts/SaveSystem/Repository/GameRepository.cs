using System.Collections.Generic;
using SaveSystem.Encryption;
using UnityEngine;
using SaveSystem.Serializer;

namespace SaveSystem.Repository
{
public class GameRepository : IGameRepository
{
	private const string GAME_STATE_KEY = "EncryptedGameStateKey";

	private readonly IEncryptionService         _encryptionService;
	private          Dictionary<string, byte[]> _gameState = new();

	public GameRepository(IEncryptionService encryptionService)
	{
		_encryptionService = encryptionService;
	}

	public void SetData<T>(T data)
	{
		var    key            = typeof(T).ToString();
		byte[] serializedData = BinarySerializer.Serialize(data);
		
		_gameState[key] = _encryptionService.Encrypt(serializedData);
	}

	public bool TryGetData<T>(out T data)
	{
		var key = typeof(T).ToString();

		if (_gameState.TryGetValue(key, out byte[] encryptedData))
		{
			byte[] decryptedData = _encryptionService.Decrypt(encryptedData);
			data = BinarySerializer.Deserialize<T>(decryptedData);
			return true;
		}

		data = default;
		return false;
	}

	public void LoadState()
	{
		if (PlayerPrefs.HasKey(GAME_STATE_KEY))
		{
			string base64String   = PlayerPrefs.GetString(GAME_STATE_KEY);
			byte[] encryptedBytes = BinarySerializer.FromBase64(base64String);
			byte[] decryptedBytes = _encryptionService.Decrypt(encryptedBytes);

			_gameState = BinarySerializer.DeserializeDictionary(decryptedBytes);
		}
		else
		{
			Debug.Log("No encrypted save found!");
		}
	}

	public void SaveState()
	{
		byte[] bytes          = BinarySerializer.SerializeDictionary(_gameState);
		byte[] encryptedBytes = _encryptionService.Encrypt(bytes);
		string base64String   = BinarySerializer.ToBase64(encryptedBytes);
		PlayerPrefs.SetString(GAME_STATE_KEY, base64String);
	}
}
}