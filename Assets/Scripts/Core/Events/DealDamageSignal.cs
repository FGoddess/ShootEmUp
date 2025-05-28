using Core.Hero;

namespace Core.Events
{
public class DealDamageSignal
{
	public HeroData Attacker { get; private set; }
	public HeroData Target   { get; private set; }
	public int      Damage   { get; private set; }

	public DealDamageSignal(HeroData attacker, HeroData target, int damage)
	{
		Attacker = attacker;
		Target   = target;
		Damage   = damage;
	}
}
}