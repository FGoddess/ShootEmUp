using Core.Hero;
using UnityEngine;

namespace Core.Events
{
public class DamageDealtSignal
{
	public HeroData Attacker { get; private set; }
	public HeroData Target   { get; private set; }
	public int      Damage   { get; private set; }

	public DamageDealtSignal(HeroData attacker, HeroData target, int damage)
	{
		Attacker = attacker;
		Target   = target;
		Damage   = damage;
	}
}
}