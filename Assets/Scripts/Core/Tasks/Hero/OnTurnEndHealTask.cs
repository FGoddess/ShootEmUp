using Abilities;
using Core.Services;
using UnityEngine;

namespace Core.Tasks.Hero
{
public class OnTurnEndHealTask : EventTask
{
	private readonly PlayerService _playerService;

	public OnTurnEndHealTask(PlayerService playerService)
	{
		_playerService = playerService;
	}

	protected override void OnStart()
	{
		Debug.Log($"OnTurnEndHealTask started");
		
		foreach (var hero in _playerService.CurrentPlayerHeroes)
			if (hero.Config.AbilityType is EAbilityType.OnTurnEndAllyHeal)
			{
				var randomHero = _playerService.GetRandomHero(_playerService.IsBluePlayerTurn);
				randomHero.ChangeHealth(1);
			}

		Complete();
	}

	protected override void OnComplete()
	{
		Debug.Log($"OnTurnEndHealTask completed");
	}
}
}