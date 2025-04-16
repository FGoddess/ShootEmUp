using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Components.Requests
{
[Game] [Event(EventTarget.Self)]
[Cleanup(CleanupMode.RemoveComponent)]
public class DamageRequest : IComponent 
{
    public GameEntity Attacker;
    public GameEntity Target;
}
} 