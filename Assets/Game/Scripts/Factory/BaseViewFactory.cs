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
	private readonly Contexts    _contexts;
	private readonly BasesConfig _config;
	private readonly Transform   _container;

	public BaseViewFactory(Contexts contexts, BasesConfig config, Transform container)
	{
		_contexts  = contexts;
		_config    = config;
		_container = container;
	}

	public void CreateView(GameEntity entity, ETeamColor teamColor)
	{
		if (!_config.BasesPrefabs.TryGetValue(teamColor, out var baseData))
			throw new Exception($"Prefab not found for TeamColor {teamColor}");

		entity.AddHealth(200);
		entity.AddTeamColor(teamColor);
		entity.AddSizeRadius(3.5f);
		entity.isBaseTag = true;

		var view = Object.Instantiate(baseData.ViewPrefab, baseData.SpawnPosition, Quaternion.identity, _container);

		view.Link(_contexts, entity);

		entity.AddPosition(view.transform.position);
	}
}
}