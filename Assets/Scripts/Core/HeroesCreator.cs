using System.Collections.Generic;
using Configs;
using Core.Services;
using UI;
using Zenject;

namespace Core
{
public class HeroesCreator : IInitializable
{
	private readonly UIService     _uiService;
	private readonly PlayerService _playerService;

	private readonly HeroesConfig _heroesConfig;


	public HeroesCreator(UIService uiService, PlayerService playerService, HeroesConfig heroesConfig)
	{
		_uiService     = uiService;
		_playerService = playerService;
		_heroesConfig  = heroesConfig;
	}

	public void Initialize()
	{
		_playerService.BluePlayerHeroes = CreateHeroes(
			_heroesConfig.BluePlayerConfigs, 
			_uiService.BluePlayer, 
			isBlueTeam: true);

		_playerService.RedPlayerHeroes = CreateHeroes(
			_heroesConfig.RedPlayerConfigs, 
			_uiService.RedPlayer, 
			isBlueTeam: false);
	}

	private List<Hero> CreateHeroes(HeroConfig[] configs, HeroListView listView, bool isBlueTeam)
	{
		var heroes = new List<Hero>(configs.Length);

		for (var i = 0; i < configs.Length; i++)
		{
			var config = configs[i];
			var view = listView.GetView(i);

			var hero = new Hero
			{
				Config = config,
				View = view,
				Health = config.MaxHealth,
				IsBlueTeam = isBlueTeam
			};

			heroes.Add(hero);
			
			SetupHeroView(view, config);
		}

		return heroes;
	}

	private void SetupHeroView(HeroView view, HeroConfig config)
	{
		view.SetActive(false);
		view.SetIcon(config.Sprite);
		view.SetStats($"{config.Damage}/{config.MaxHealth}");
	}
}
}