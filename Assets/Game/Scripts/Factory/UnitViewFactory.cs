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

	private readonly Dictionary<(EUnitType, ETeamColor), List<UnitView>> _pools;

	public UnitViewFactory(Contexts contexts, UnitsConfig config)
	{
		_contexts = contexts;
		_config   = config;
		_pools    = new Dictionary<(EUnitType, ETeamColor), List<UnitView>>();

		foreach (var unitData in _config.UnitsDataMap)
			_pools[(unitData.Key.Item1, unitData.Key.Item2)] = new List<UnitView>();
	}

	public UnitView CreateView(GameEntity entity, EUnitType unitType, ETeamColor teamColor)
	{
		if (!_config.UnitsDataMap.TryGetValue((unitType, teamColor), out var unitData))
			throw new Exception($"Prefab not found for type {unitType}, TeamColor {teamColor}");

		var data = _config.UnitsDataMap[(unitType, teamColor)];

		entity.AddHealth(data.Health);
		entity.AddAttackRange(data.AttackRange);
		entity.AddTeamTag(teamColor);
		entity.AddSizeRadius(data.SizeRadius);
		entity.AddMove(data.MoveSpeed);
		entity.AddAttackCooldown(data.AttackCooldown, 0f);
		entity.AddDamage(data.Damage);

		var view = _pools[(unitType, teamColor)].FirstOrDefault(v => !v.gameObject.activeInHierarchy);

		if (view != null)
		{
			view.gameObject.SetActive(true);
		}
		else
		{
			view = Object.Instantiate(unitData.ViewPrefab);
			_pools[(unitType, teamColor)].Add(view);
		}

		view.transform.position = new Vector3(
			Random.Range(unitData.SpawnPosition.x - 2f, unitData.SpawnPosition.x + 2f),
			0f,
			Random.Range(unitData.SpawnPosition.z - 5f, unitData.SpawnPosition.z + 5f)
		);

		entity.AddPosition(view.transform.position);

		view.Link(_contexts, entity);
		
		return view;
	}
}
}