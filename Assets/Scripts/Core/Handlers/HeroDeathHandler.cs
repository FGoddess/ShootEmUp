using Core.Events;
using Core.Services;
using UnityEngine;
using Zenject;

namespace Core.Handlers
{
public class HeroDeathHandler
{
	private readonly PlayerService _playerService;
	private readonly SignalBus     _signalBus;

	public HeroDeathHandler(PlayerService playerService, SignalBus signalBus)
	{
		_playerService = playerService;
		_signalBus     = signalBus;
	}

	public void OnDamageDealt(DamageDealtSignal signal)
	{
		if (signal.Target.Health > 0)
			return;

		Debug.Log($"Hero {signal.Target.Config.name} died");

		signal.Target.View.SetActive(false);
		signal.Target.View.gameObject.SetActive(false);

		if (signal.Target.IsBlueTeam)
			_playerService.BluePlayerHeroes.Remove(signal.Target);
		else
			_playerService.RedPlayerHeroes.Remove(signal.Target);

		_signalBus.Fire(new HeroDeathSignal(signal.Target));
	}
}
}