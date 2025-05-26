using Abilities;
using Core.Events;
using Core.Services;
using UnityEngine;
using Zenject;

namespace Core.Tasks.Hero
{
public class DealDamageTask : EventTask
{
	private readonly SignalBus     _signalBus;
	private readonly PlayerService _playerService;


	public DealDamageTask(PlayerService playerService, SignalBus signalBus)
	{
		_playerService = playerService;
		_signalBus     = signalBus;
	}

	protected override void OnStart()
	{
		Debug.Log("DealDamageTask started");
		_signalBus.Fire(new DealDamageSignal(_playerService.SelectedAttacker,
		                                     _playerService.SelectedTarget,
		                                     _playerService.SelectedAttacker.Config.Damage));

		if (_playerService.SelectedAttacker.Config.AbilityType is not EAbilityType.OnAttackNoBackDamage)
			_signalBus.Fire(new DealDamageSignal(_playerService.SelectedTarget,
			                                     _playerService.SelectedAttacker,
			                                     _playerService.SelectedTarget.Config.Damage));

		Complete();
	}

	protected override void OnComplete()
	{
		Debug.Log("DealDamageTask completed");
	}
}
}