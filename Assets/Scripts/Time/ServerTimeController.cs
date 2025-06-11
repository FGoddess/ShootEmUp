using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

namespace Time
{
public class ServerTimeController : IInitializable
{
	private const string SERVER_URL = "https://yandex.com/time/sync.json";

	public bool IsServerTimeReceived { get; private set; }

	private DateTime _localTime;
	private DateTime _serverTime;
	private TimeSpan _elapsedTime;

	public void Initialize()
	{
		FetchTime().Forget();
	}

	public DateTime GetCurrentTime()
	{
		if (!IsServerTimeReceived)
			throw new Exception("Actual time is not received");

		_elapsedTime = DateTime.UtcNow - _localTime;
		return _serverTime.Add(_elapsedTime);
	}

	private async UniTaskVoid FetchTime()
	{
		var request = UnityWebRequest.Get(SERVER_URL);
		await request.SendWebRequest().ToUniTask();

		if (request.result == UnityWebRequest.Result.Success)
		{
			var data = JsonUtility.FromJson<TimeData>(request.downloadHandler.text);

			_serverTime = new DateTime(1970, 1, 1) + TimeSpan.FromMilliseconds(data.time);
			_localTime  = DateTime.UtcNow;

			IsServerTimeReceived = true;

			Debug.Log($"Fetch success. Server time: {_serverTime}, Local time: {_localTime}");
		}
		else
		{
			Debug.LogError($"Fetch error: {request.error}");
		}
	}
}
}