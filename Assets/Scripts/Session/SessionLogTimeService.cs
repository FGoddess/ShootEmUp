using System;
using Cysharp.Threading.Tasks;
using DI.Contexts;
using Session.Views;
using Time;
using Zenject;

namespace Session
{
public class SessionLogTimeService : IInitializable, IGameService
{
	private readonly ServerTimeController _serverTimeController;
	private readonly SessionLogTimeView   _view;

	public DateTime CurrentEnterTime { get; private set; }

	public SessionLogTimeService(ServerTimeController serverTimeController, SessionLogTimeView view)
	{
		_serverTimeController = serverTimeController;
		_view                 = view;
	}

	public void Initialize()
	{
		SetEnterTimeAsync().Forget();
	}

	private async UniTask SetEnterTimeAsync()
	{
		while (!_serverTimeController.IsServerTimeReceived)
			await UniTask.Delay(1000, DelayType.Realtime);

		CurrentEnterTime = _serverTimeController.GetCurrentTime();
	}

	public void SetupLastTime(DateTime startTime, DateTime endTime)
	{
		_view.SetData(startTime.ToString("dd.MM.yyyy HH:mm:ss"), endTime.ToString("dd.MM.yyyy HH:mm:ss"));
	}
}
}