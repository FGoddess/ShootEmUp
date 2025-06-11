using System;
using System.Collections.Generic;
using Session;
using Time;

namespace SaveSystem.SaveLoad
{
public class LogTimeSaveLoader : SaveLoader<SessionLogTimeService, SessionTimeSave>
{
	private readonly ServerTimeController _serverTimeController;

	public LogTimeSaveLoader(ServerTimeController serverTimeController)
	{
		_serverTimeController = serverTimeController;
	}

	protected override SessionTimeSave ConvertToData(SessionLogTimeService service)
	{
		return new SessionTimeSave
		{
			StartTime = service.CurrentEnterTime.ToString(),
			EndTime   = _serverTimeController.GetCurrentTime().ToString()
		};
	}

	protected override void SetupData(SessionLogTimeService service, SessionTimeSave data)
	{
		if (string.IsNullOrEmpty(data.StartTime) || string.IsNullOrEmpty(data.EndTime))
			return;

		service.SetupLastTime(DateTime.Parse(data.StartTime), DateTime.Parse(data.EndTime));
	}
}
}