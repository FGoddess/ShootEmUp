using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using Types;
using UnityEngine;
using Views;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Factory
{
public class UnitViewFactory : IUnitViewFactory
{
	private readonly Contexts    _contexts;
	private readonly UnitsConfig _config;
	private readonly Transform   _container;

	private readonly Dictionary<(EUnitType, ETeamColor), List<UnitView>> _pools;

	public UnitViewFactory(Contexts contexts, UnitsConfig config, Transform container)
	{
		_contexts  = contexts;
		_config    = config;
		_container = container;

		_pools = new Dictionary<(EUnitType, ETeamColor), List<UnitView>>();

		foreach (var unitData in _config.UnitsDataMap)
			_pools[(unitData.Key.Item1, unitData.Key.Item2)] = new List<UnitView>();
	}

	public void CreateView(GameEntity entity, EUnitType unitType, ETeamColor teamColor)
	{
		if (!_config.UnitsDataMap.TryGetValue((unitType, teamColor), out var unitData))
			throw new Exception($"Prefab not found for type {unitType}, TeamColor {teamColor}");

		var data = _config.UnitsDataMap[(unitType, teamColor)];

		entity.AddHealth(data.Health);
		entity.AddAttackRange(data.AttackRange);
		entity.AddTeamColor(teamColor);
		entity.AddSizeRadius(data.SizeRadius);
		entity.AddMove(data.MoveSpeed);
		entity.AddAttackCooldown(data.AttackCooldown, 0f);
		entity.AddDamage(data.Damage);
		entity.AddUnitType(unitType);

		var view = _pools[(unitType, teamColor)].FirstOrDefault(v => !v.gameObject.activeInHierarchy);

		if (view != null)
		{
			view.gameObject.SetActive(true);
		}
		else
		{
			view = Object.Instantiate(unitData.ViewPrefab, _container);
			_pools[(unitType, teamColor)].Add(view);
		}

		view.transform.position = new Vector3(
			Random.Range(unitData.MinSpawnPosRange.x, unitData.MaxSpawnPosRange.x),
			0f,
			Random.Range(unitData.MinSpawnPosRange.y, unitData.MaxSpawnPosRange.y)
		);

		entity.AddPosition(view.transform.position);
		entity.AddFacing(view.transform.rotation.eulerAngles);

		view.Link(_contexts, entity);
	}
}
}