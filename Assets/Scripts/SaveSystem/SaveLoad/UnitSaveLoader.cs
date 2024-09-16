using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameEngine;
using SaveSystem.Data;
using UnityEditor;

namespace SaveSystem.SaveLoad
{
public class UnitSaveLoader : SaveLoader<UnitManager, List<UnitData>>
{
	protected override List<UnitData> ConvertToData(UnitManager service)
	{
		var data = new List<UnitData>();
		foreach (var unit in service.GetAllUnits())
			data.Add(new UnitData
			{
				Type      = unit.Type,
				HitPoints = unit.HitPoints,
				Position  = unit.transform.position,
				Rotation  = unit.transform.eulerAngles
			});
		return data;
	}

	protected override void SetupData(UnitManager service, List<UnitData> data)
	{
		foreach (var unit in service.GetAllUnits().ToList())
			service.DestroyUnit(unit);

		foreach (var unitData in data)
		{
			var prefab = GetUnitPrefabByType(unitData.Type);
			if (prefab != null)
			{
				var unit = service.SpawnUnit(prefab, unitData.Position, Quaternion.Euler(unitData.Rotation));
				unit.HitPoints = unitData.HitPoints;
			}
		}
	}

	private Unit GetUnitPrefabByType(string unitType)
	{
		var path   = $"Prefabs/UnitObjects/{unitType}";
		var prefab = Resources.Load<Unit>(path);

		if (prefab == null)
			Debug.LogError($"There is no prefab for type {unitType}");

		return prefab;
	}
}
}