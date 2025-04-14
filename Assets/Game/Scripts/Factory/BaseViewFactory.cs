using System;
using Configs;
using Types;
using UnityEngine;
using Views;
using Object = UnityEngine.Object;

namespace Factory
{
public class BaseViewFactory : IBaseViewFactory
{
	private readonly Contexts _contexts;

	private readonly BasesConfig _config;

	public BaseViewFactory(Contexts contexts, BasesConfig config)
	{
		_contexts = contexts;
		_config   = config;
	}

	public BaseView CreateView(GameEntity entity, ETeamColor teamColor)
	{
		if (!_config.BasesPrefabs.TryGetValue(teamColor, out var baseData))
			throw new Exception($"Prefab not found for TeamColor {teamColor}");

		var view = Object.Instantiate(baseData.ViewPrefab, baseData.SpawnPosition, Quaternion.identity);
		view.Link(_contexts, entity);
		return view;
	}
}
}