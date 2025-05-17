using Core.Events;
using Core.Services;
using Core.Tasks;
using UI;
using Zenject;

namespace Core.Handlers
{
public class SelectTargetHandler
{
	private readonly SelectTargetTask _selectTargetTask;
	private readonly UIService        _uIService;
	private readonly PlayerService    _playerService;

	public SelectTargetHandler(SelectTargetTask selectTargetTask, UIService uIService, PlayerService playerService)
	{
		_selectTargetTask = selectTargetTask;
		_uIService        = uIService;
		_playerService    = playerService;
	}

	public void SetupTargetSelection(SelectTargetSignal signal)
	{
		if (_playerService.IsBluePlayerTurn)
		{
			_uIService.RedPlayer.SetActive(true);
			_uIService.RedPlayer.OnHeroClicked += OnHeroClicked;
		}
		else
		{
			_uIService.BluePlayer.SetActive(true);
			_uIService.BluePlayer.OnHeroClicked += OnHeroClicked;
		}
	}

	private void OnHeroClicked(HeroView view)
	{
		view.SetActive(true);
		_selectTargetTask.Complete();

		if (_playerService.IsBluePlayerTurn)
		{
			_uIService.RedPlayer.SetActive(true);
			_uIService.RedPlayer.OnHeroClicked -= OnHeroClicked;
		}
		else
		{
			_uIService.BluePlayer.SetActive(false);
			_uIService.BluePlayer.OnHeroClicked -= OnHeroClicked;
		}
	}
}
}