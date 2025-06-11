using System;
using System.Collections.Generic;
using Chests;
using Chests.Configs;

namespace SaveSystem.SaveLoad
{
public class ChestsSaveLoader : SaveLoader<ChestsService, ChestListSave>
{
	private readonly ChestConfigsList _chestConfigsList;

	public ChestsSaveLoader(ChestConfigsList chestConfigsList)
	{
		_chestConfigsList = chestConfigsList;
	}

	protected override ChestListSave ConvertToData(ChestsService service)
	{
		var chests     = service.CurrentChests;
		var chestSaves = new List<ChestSave>();

		foreach (var chest in chests)
		{
			var chestSave = new ChestSave
			{
				Id         = chest.Config.Id,
				CreateTime = chest.CreateTime.ToString()
			};

			chestSaves.Add(chestSave);
		}

		return new ChestListSave
		{
			ChestSaves = chestSaves.ToArray()
		};
	}

	protected override void SetupData(ChestsService service, ChestListSave data)
	{
		var chests = new List<Chest>();

		foreach (var chestSave in data.ChestSaves)
		{
			var chestConfig = _chestConfigsList.GetConfig(chestSave.Id);
			chests.Add(new Chest(chestConfig, DateTime.Parse(chestSave.CreateTime)));
		}

		service.SetupChests(chests);
	}
}
}