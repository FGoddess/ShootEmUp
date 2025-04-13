using Entitas;
using UnityEngine;

namespace Systems
{
public class PositionSystem : IExecuteSystem
{
	private readonly IGroup<GameEntity> _positionEntities;

	public PositionSystem(Contexts contexts)
	{
		_positionEntities = contexts.game.GetGroup(GameMatcher.Position);
	}

	private float _timer;

	public void Execute()
	{
		_timer += Time.deltaTime;

		if (_timer < 1.0f)
			return;

		_timer = 0f;

		foreach (var entity in _positionEntities)
			entity.ReplacePosition(entity.position.Value + Vector3.forward * 0.5f);
	}
}
}