using Core.Events;
using Core.Services;
using Core.Tasks;
using UI;
using Zenject;

namespace Core.Handlers
{
public class SelectHeroHandler
{
	private readonly SelectHeroTask _selectHeroTask;
	private readonly UIService      _uIService;
	private readonly PlayerService  _playerService;


	public SelectHeroHandler(SelectHeroTask selectHeroTask, UIService uIService, PlayerService playerService)
	{
		_selectHeroTask = selectHeroTask;
		_uIService      = uIService;
		_playerService  = playerService;
	}

	public void SetupHeroSelection(SelectHeroSignal signal)
	{
		if (_playerService.IsBluePlayerTurn)
		{
			_uIService.BluePlayer.SetActive(true);
			_uIService.BluePlayer.OnHeroClicked += OnHeroClicked;
		}
		else
		{
			_uIService.RedPlayer.SetActive(true);
			_uIService.RedPlayer.OnHeroClicked += OnHeroClicked;
		}
	}

	private void OnHeroClicked(HeroView view)
	{
		view.SetActive(true);
		_selectHeroTask.Complete();

		if (_playerService.IsBluePlayerTurn)
		{
			_uIService.BluePlayer.SetActive(false);
			_uIService.BluePlayer.OnHeroClicked -= OnHeroClicked;
		}
		else
		{
			_uIService.RedPlayer.SetActive(true);
			_uIService.RedPlayer.OnHeroClicked -= OnHeroClicked;
		}
	}
}
}