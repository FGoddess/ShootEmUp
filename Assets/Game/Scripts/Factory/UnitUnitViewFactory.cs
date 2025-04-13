using System;
using System.Collections.Generic;
using Types;
using Views;
using Object = UnityEngine.Object;

namespace Factory
{
public class UnitUnitViewFactory : IUnitViewFactory
{
	private readonly Contexts _contexts;

	private readonly Dictionary<(EUnitType, ETeamColor), UnitView> _prefabs;

	public UnitUnitViewFactory(Contexts contexts, Dictionary<(EUnitType, ETeamColor), UnitView> prefabs)
	{
		_contexts = contexts;
		_prefabs  = prefabs;
	}

	public UnitView CreateView(GameEntity entity, EUnitType unitType, ETeamColor teamColor)
	{
		if (!_prefabs.TryGetValue((unitType, teamColor), out var prefab))
			throw new Exception($"Prefab not found for type {unitType}, TeamColor {teamColor}");

		var view = Object.Instantiate(prefab);
		view.Link(_contexts, entity);
		return view;
	}
}
}