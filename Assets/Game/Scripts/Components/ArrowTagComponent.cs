using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Components
{
[Game] [Event(EventTarget.Self, EventType.Removed)]
public class ArrowTagComponent : IComponent { }
}