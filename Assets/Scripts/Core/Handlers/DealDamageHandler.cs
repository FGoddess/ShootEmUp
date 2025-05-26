using Core.Events;
using UnityEngine;
using Zenject;

namespace Core.Handlers
{
public class DealDamageHandler
{
	private readonly SignalBus _signalBus;

	public DealDamageHandler(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	public void DealDamage(DealDamageSignal signal)
	{
		if (signal.Target.HasHolyShield)
		{
			signal.Target.HasHolyShield = false;
			Debug.Log($"Deal Damage Not Dealt: Holy Shield");
			return;
		}

		signal.Target.ChangeHealth(-signal.Damage);

		signal.Target.View.SetStats($"{signal.Target.Config.Damage}/{signal.Target.Health}");

		_signalBus.Fire(new DamageDealtSignal(signal.Attacker, signal.Target, signal.Damage));
		
		Debug.Log($"Deal Damage Dealt.");
	}
}
}