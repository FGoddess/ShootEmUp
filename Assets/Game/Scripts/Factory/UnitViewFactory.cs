using System;
using Configs;
using Types;
using UnityEngine;
using Views;
using Object = UnityEngine.Object;

namespace Factory
{
public class UnitViewFactory : IUnitViewFactory
{
	private readonly Contexts _contexts;

	private readonly UnitsConfig _config;

	public UnitViewFactory(Contexts contexts, UnitsConfig config)
	{
		_contexts = contexts;
		_config   = config;
	}

	//TODO: add container
	public UnitView CreateView(GameEntity entity, EUnitType unitType, ETeamColor teamColor)
	{
		if (!_config.UnitsPrefabs.TryGetValue((unitType, teamColor), out var unitData))
			throw new Exception($"Prefab not found for type {unitType}, TeamColor {teamColor}");

		var view = Object.Instantiate(unitData.ViewPrefab, unitData.SpawnPosition, Quaternion.identity);
		view.Link(_contexts, entity);
		return view;
	}
}
}