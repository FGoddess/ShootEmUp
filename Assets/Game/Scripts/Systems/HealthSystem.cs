using Entitas;
using UnityEngine;

namespace Systems
{
public class HealthSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _healthEntities;
	
	public HealthSystem(Contexts contexts)
	{
		_healthEntities = contexts.game.GetGroup(GameMatcher.Health);
	}
	
	public void Execute()
	{
		foreach (var entity in _healthEntities)
		{
			//Debug.Log(entity.health.Value);
		}
	}
}
}