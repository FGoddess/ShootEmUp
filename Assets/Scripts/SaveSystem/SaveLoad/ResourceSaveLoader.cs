using System.Collections.Generic;
using GameEngine;

namespace SaveSystem.SaveLoad
{
public class ResourceSaveLoader : SaveLoader<ResourceService, Dictionary<string, int>>
{
	protected override Dictionary<string, int> ConvertToData(ResourceService service)
	{
		var data = new Dictionary<string, int>();
		foreach (var resource in service.GetResources())
			data.Add(resource.ID, resource.Amount);

		return data;
	}

	protected override void SetupData(ResourceService service, Dictionary<string, int> data)
	{
		foreach (var resource in service.GetResources())
			resource.Amount = data[resource.ID];
	}
}
}