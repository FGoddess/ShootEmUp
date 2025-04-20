using Entitas;

namespace Components.Requests
{
[Game]
public class ArrowCreateRequest : IComponent
{
    public GameEntity Attacker;
    public GameEntity Target;
}
} 