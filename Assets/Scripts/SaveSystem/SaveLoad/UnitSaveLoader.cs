using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using GameEngine;
using SaveSystem.Data;

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
		var existingUnits  = service.GetAllUnits().ToList();
		var unitsData      = new List<UnitData>(data);
		var unitsToDestroy = new List<Unit>();

		foreach (var unit in existingUnits)
		{
			var matchingData = unitsData.FirstOrDefault(u => u.Type == unit.Type);
			if (matchingData != null)
			{
				UpdateUnit(unit, matchingData);
				unitsData.Remove(matchingData);
			}
			else
			{
				unitsToDestroy.Add(unit);
			}
		}

		foreach (var unit in unitsToDestroy)
			service.DestroyUnit(unit);

		foreach (var unitData in unitsData)
		{
			var prefab = GetUnitPrefabByType(unitData.Type);
			var unit = service.SpawnUnit(prefab, unitData.Position, Quaternion.Euler(unitData.Rotation));
			unit.HitPoints = unitData.HitPoints;
		}
	}

	private void UpdateUnit(Unit unit, UnitData data)
	{
		unit.HitPoints          = data.HitPoints;
		unit.transform.position = data.Position;
		unit.transform.rotation = Quaternion.Euler(data.Rotation);
	}

	private Unit GetUnitPrefabByType(string unitType)
	{
		var path   = $"Prefabs/UnitObjects/{unitType}";
		var prefab = Resources.Load<Unit>(path);
		
		if (prefab == null)
			throw new Exception($"There is no prefab for type {unitType}");

		return prefab;
	}
}
}