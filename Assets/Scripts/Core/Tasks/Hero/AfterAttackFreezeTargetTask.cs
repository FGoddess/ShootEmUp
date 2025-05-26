using Abilities;
using Core.Services;
using UnityEngine;

namespace Core.Tasks.Hero
{
public class AfterAttackFreezeTargetTask : EventTask
{
	private readonly PlayerService _playerService;

	public AfterAttackFreezeTargetTask(PlayerService playerService)
	{
		_playerService = playerService;
	}

	protected override void OnStart()
	{
		Debug.Log($"AfterAttackFreezeTargetTask started");
		_playerService.SelectedTarget.FrozenTurns = 1;

		Complete();
	}

	protected override void OnComplete()
	{
		Debug.Log($"AfterAttackFreezeTargetTask completed");
	}
}
}