using Entitas;
using UnityEngine;

namespace Systems
{
public class CleanupSystem : ICleanupSystem
{
	private readonly GameContext _context;

	private readonly IGroup<GameEntity> _requests;

	public CleanupSystem(Contexts contexts)
	{
		_context = contexts.game;

		_requests = _context.GetGroup(GameMatcher.AnyOf(GameMatcher.DamageRequest,
		                                                GameMatcher.CreateUnitRequest,
		                                                GameMatcher.UnitDiedEvent));
	}

	public void Cleanup()
	{
		var entities = _requests.GetEntities();
		foreach (var entity in entities)
			entity.Destroy();
	}
}
}