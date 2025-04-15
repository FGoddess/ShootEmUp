using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Components.Requests
{
[Game] [Event(EventTarget.Self)]
public class AttackRequest : IComponent 
{
    public GameEntity Attacker;
    public GameEntity Target;
}
}