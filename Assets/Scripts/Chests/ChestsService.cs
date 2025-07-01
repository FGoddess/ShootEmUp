using System;
using System.Collections.Generic;
using System.Linq;
using Chests.Configs;
using DI.Contexts;
using Rewards;
using Sirenix.Utilities;
using Time;
using UniRx;
using UnityEngine;

namespace Chests
{
public class ChestsService : IGameService
{
	private readonly ServerTimeController _serverTimeController;
	private readonly IServicesContext     _servicesContext;

	private readonly ReactiveCollection<Chest> _currentChests = new();
	private          TimeSpan                  _chestTimeCached;

	private const int MAX_CHESTS_AMOUNT = 4;

	public          IReadOnlyReactiveCollection<Chest> CurrentChests => _currentChests;
	public readonly Subject<Chest>                     ChestOpened = new();

	public ChestsService(ServerTimeController serverTimeController, IServicesContext servicesContext)
	{
		_serverTimeController = serverTimeController;
		_servicesContext      = servicesContext;
	}

	public void SetupChests(IEnumerable<Chest> chests)
	{
		_currentChests.Clear();
		_currentChests.AddRange(chests);
	}

	public void Add(ChestConfig config)
	{
		if (_currentChests.Count >= MAX_CHESTS_AMOUNT)
		{
			Debug.LogWarning($"Достигнуто максимальное количество сундуков: {MAX_CHESTS_AMOUNT}");
			return;
		}

		_currentChests.Add(new Chest(config, _serverTimeController.GetCurrentTime()));
	}

	public void Remove(Chest chest)
	{
		_currentChests.Remove(chest);
	}

	public void Open(Chest chest)
	{
		Debug.Log($"Открыт сундук: {chest.Config.Name}");

		foreach (var reward in chest.Config.Rewards)
		{
			Debug.Log($"Получена награда: {reward.GetDescription()}");
			reward.Apply(_servicesContext);
		}

		chest.RestartTimer(_serverTimeController.GetCurrentTime());
		ChestOpened.OnNext(chest);
	}

	public bool TryGetChestTimeLeft(Chest chest, out TimeSpan timeLeft)
	{
		timeLeft = TimeSpan.MaxValue;

		if (!_serverTimeController.IsServerTimeReceived)
			return false;

		_chestTimeCached = TimeSpan.FromMinutes(chest.Config.OpenTimeMins);
		var currentTime = _serverTimeController.GetCurrentTime();

		if (chest.CreateTime.Add(_chestTimeCached) <= currentTime)
			timeLeft = TimeSpan.Zero;
		else
			timeLeft = chest.CreateTime + _chestTimeCached - currentTime;

		return true;
	}
}
}