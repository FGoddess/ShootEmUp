using Entitas;

namespace Components
{
public class AttackCooldownComponent : IComponent
{
	public float CooldownDuration;
	public float LastAttackTime;
}
}