using Core.Services;
using UnityEngine;

namespace Core.Tasks.Hero
{
public class AfterAttackLifeStealChanceTask : EventTask
{
	private readonly PlayerService _playerService;

	public AfterAttackLifeStealChanceTask(PlayerService playerService)
	{
		_playerService = playerService;
	}

	protected override void OnStart()
	{
		Debug.Log($"HeroLifeStealTask started");
		if (Random.value > 0.5f)
		{
			Complete();
			return;
		}

		Debug.Log($"HeroLifeStealTask chance");
		_playerService.SelectedAttacker.ChangeHealth(_playerService.SelectedAttacker.Config.Damage);
		Complete();
	}

	protected override void OnComplete()
	{
		Debug.Log($"HeroWrongTargetChanceTask completed");

	}
}
}