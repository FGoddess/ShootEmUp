using Core.Services;
using UnityEngine;

namespace Core.Tasks
{
public class CleanupTask : EventTask
{
	private readonly PlayerService _playerService;

	public CleanupTask(PlayerService playerService)
	{
		_playerService = playerService;
	}

	protected override void OnStart()
	{
		Debug.Log("Start cleanup task");

		foreach (var hero in _playerService.CurrentPlayerHeroes)
			if (hero.IsFrozen)
				hero.FrozenTurns--;

		_playerService.SetNextPlayerTurn();
		_playerService.Cleanup();
		Complete();
	}

	protected override void OnComplete()
	{
		Debug.Log("Complete cleanup task");
	}
}
}