using System;
using System.Collections.Generic;
using System.Linq;
using Chests.Configs;
using DI.Contexts;
using Rewards;
using Sirenix.Utilities;
using Time;
using UniRx;

namespace Chests
{
public class ChestsService : IGameService
{
	private readonly ServerTimeController   _serverTimeController;
	private readonly RewardsApplyController _rewardsApplyController;

	private readonly ReactiveCollection<Chest> _currentChests = new();
	private          TimeSpan                  _chestTimeCached;

	public IReadOnlyReactiveCollection<Chest> CurrentChests => _currentChests;

	public ChestsService(ServerTimeController serverTimeController, RewardsApplyController rewardsApplyController)
	{
		_serverTimeController   = serverTimeController;
		_rewardsApplyController = rewardsApplyController;
	}

	public void SetupChests(IEnumerable<Chest> chests)
	{
		_currentChests.Clear();
		_currentChests.AddRange(chests);
	}

	public void Add(ChestConfig config)
	{
		_currentChests.Add(new Chest(config, _serverTimeController.GetCurrentTime()));
	}

	public void Remove(Chest chest)
	{
		_currentChests.Remove(chest);
	}

	public void Open(Chest chest)
	{
		foreach (var reward in chest.Config.Rewards)
			reward.Accept(_rewardsApplyController);

		Remove(chest);
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