using System;
using Cysharp.Threading.Tasks;
using Session.Views;
using Time;
using Zenject;

namespace Session
{
public class SessionDurationController : IInitializable
{
	private readonly SessionDurationView _view;

	private TimeSpan _currentDuration;

	public SessionDurationController(SessionDurationView view)
	{
		_view = view;
	}

	public void Initialize()
	{
		DisplayTime().Forget();
	}

	private async UniTask DisplayTime()
	{
		while (true)
		{
			_view.SetDurationText(_currentDuration.ToString(@"hh\:mm\:ss"));
			await UniTask.Delay(1000);
			_currentDuration = _currentDuration.Add(TimeSpan.FromSeconds(1));
		}
	}
}
}