using System.Collections.Generic;
using Abilities;
using Core.Events;
using Core.Hero;
using Core.Services;
using UnityEngine;
using Zenject;

namespace Core.Handlers
{
public class DamageAllHandler
{
	private readonly PlayerService _playerService;
	private readonly SignalBus     _signalBus;

	public DamageAllHandler(PlayerService playerService, SignalBus signalBus)
	{
		_playerService = playerService;
		_signalBus     = signalBus;
	}

	public void DamageAll(DamageDealtSignal signal)
	{
		if (signal.Target.Config.AbilityType is not EAbilityType.OnDamagedDealDamageToAll)
			return;

		DealDamage(signal.Target, _playerService.BluePlayerHeroes.ToArray());
		DealDamage(signal.Target, _playerService.RedPlayerHeroes.ToArray());
	}

	private void DealDamage(HeroData attacker, HeroData[] heroes)
	{
		foreach (var hero in heroes)
		{
			if (hero == attacker)
				continue;

			_signalBus.Fire(new DealDamageSignal(attacker, hero, 1));
		}
	}
}
}