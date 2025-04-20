using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Components
{
[Event(EventTarget.Self)]
public class FacingComponent : IComponent
{
	public Vector3 Direction;
}
} 