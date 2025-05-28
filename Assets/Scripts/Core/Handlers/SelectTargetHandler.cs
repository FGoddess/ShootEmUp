using Core.Events;
using Core.Services;
using Core.Tasks;
using UI;

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
		var playerView = _uIService.GetPlayerView(!_playerService.IsBluePlayerTurn);

		playerView.SetActive(true);
		playerView.OnHeroClicked += OnHeroClicked;
	}

	private void OnHeroClicked(HeroView view)
	{
		var playerView = _uIService.GetPlayerView(!_playerService.IsBluePlayerTurn);

		playerView.SetActive(false);
		playerView.OnHeroClicked -= OnHeroClicked;

		foreach (var heroData in _playerService.CurrentEnemyHeroes)
			if (heroData.View == view)
				_playerService.SelectedTarget = heroData;

		_selectTargetTask.Complete();
	}
}
}