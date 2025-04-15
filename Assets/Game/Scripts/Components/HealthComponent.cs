using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Components
{
[Event(EventTarget.Self)]
public class HealthComponent : IComponent
{
	public int Value;
}
}