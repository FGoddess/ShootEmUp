using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Components
{
[Event(EventTarget.Self)]
public class PositionComponent : IComponent
{
	public Vector3 Value;
}
}