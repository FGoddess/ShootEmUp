using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Components
{
[Game] 
[Event(EventTarget.Self)]
public class AttackProcess : IComponent
{
	public GameEntity Target;
	public float      StartTime;
	public float      HitTime;
}
}