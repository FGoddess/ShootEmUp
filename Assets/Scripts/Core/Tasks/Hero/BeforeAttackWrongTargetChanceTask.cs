using Core.Services;
using UnityEngine;

namespace Core.Tasks.Hero
{
public class BeforeAttackWrongTargetChanceTask : EventTask
{
	private readonly PlayerService _playerService;

	public BeforeAttackWrongTargetChanceTask(PlayerService playerService)
	{
		_playerService = playerService;
	}

	protected override void OnStart()
	{
		Debug.Log($"HeroWrongTargetChanceTask started");
		if (Random.value > 0.5f)
		{
			Complete();
			return;
		}

		Debug.Log($"HeroWrongTargetChanceTask chance");
		_playerService.SelectedTarget.View.SetActive(false);

		var heroes = _playerService.CurrentEnemyHeroes;
		_playerService.SelectedTarget = heroes[Random.Range(0, heroes.Count)];
		
		Complete();
	}

	protected override void OnComplete()
	{
		Debug.Log($"HeroWrongTargetChanceTask completed");
	}
}
}