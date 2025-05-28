using Core.Events;
using Core.Services;

namespace Core.Handlers
{
public class GameEndHandler
{
	private readonly PlayerService _playerService;
	private readonly UiWinScreen   _uiWinScreen;

	public GameEndHandler(PlayerService playerService, UiWinScreen uiWinScreen)
	{
		_playerService = playerService;
		_uiWinScreen   = uiWinScreen;
	}

	public void OnHeroDeath(HeroDeathSignal signal)
	{
		if (_playerService.BluePlayerHeroes.Count == 0)
		{
			_uiWinScreen.Show();
			_uiWinScreen.SetText("Red team wins!");
		}
		else if (_playerService.RedPlayerHeroes.Count == 0)
		{
			_uiWinScreen.Show();
			_uiWinScreen.SetText("Blue team wins!");
		}
	}
}
}