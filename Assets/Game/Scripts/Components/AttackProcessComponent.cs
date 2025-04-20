using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Components
{
[Game]
[Event(EventTarget.Self)]
public class AttackProcessComponent : IComponent
{
	public float StartTime;
	public float HitTime;
}
}