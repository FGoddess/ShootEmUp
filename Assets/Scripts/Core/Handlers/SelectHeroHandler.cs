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
		var view = _uIService.GetPlayerView(_playerService.IsBluePlayerTurn);
		
		view.SetActive(true);
		view.OnHeroClicked += OnHeroClicked;
	}

	private void OnHeroClicked(HeroView view)
	{
		var playerView = _uIService.GetPlayerView(_playerService.IsBluePlayerTurn);
		
		foreach (var heroData in _playerService.CurrentPlayerHeroes)
			if (heroData.View == view)
			{
				if (heroData.IsFrozen)
					return;

				playerView.SetActive(false);
				playerView.OnHeroClicked -= OnHeroClicked;

				_playerService.SelectedAttacker = heroData;
			}

		view.SetActive(true);

		_selectHeroTask.Complete();
	}
}
}