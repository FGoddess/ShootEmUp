using System;
using System.Collections.Generic;
using Abilities;
using Configs;
using Core.Services;
using Core.Tasks;
using Core.Tasks.Hero;
using UI;
using Zenject;

namespace Core
{
public class HeroesSetupSystem : IInitializable
{
	private readonly UIService     _uiService;
	private readonly PlayerService _playerService;

	private readonly HeroesConfig _heroesConfig;

	private readonly DiContainer _container;


	public HeroesSetupSystem(UIService uiService, PlayerService playerService, HeroesConfig heroesConfig, DiContainer container)
	{
		_uiService     = uiService;
		_playerService = playerService;
		_heroesConfig  = heroesConfig;
		_container     = container;
	}

	public void Initialize()
	{
		_playerService.BluePlayerHeroes = CreateHeroes(
			_heroesConfig.BluePlayerConfigs,
			_uiService.BluePlayer,
			true);

		_playerService.RedPlayerHeroes = CreateHeroes(
			_heroesConfig.RedPlayerConfigs,
			_uiService.RedPlayer,
			false);
	}

	private List<HeroData> CreateHeroes(HeroConfig[] configs, HeroListView listView, bool isBlueTeam)
	{
		var heroes = new List<HeroData>(configs.Length);

		for (var i = 0; i < configs.Length; i++)
		{
			var config = configs[i];
			var view   = listView.GetView(i);

			var hero = new HeroData
			{
				Config          = config,
				View            = view,
				Health          = config.MaxHealth,
				IsBlueTeam      = isBlueTeam,
				ActionsPipeline = new HeroPipeline(),
				TurnEndPipeline = new HeroPipeline()
			};

			switch (config.AbilityType)
			{
				case EAbilityType.OnTurnEndDamageRandomTarget:
					var onTurnEndTaskDamageTask = _container.Instantiate<OnTurnEndDamageTask>();
					onTurnEndTaskDamageTask.SetHero(hero);

					hero.ActionsPipeline.AddTask(_container.Instantiate<DealDamageTask>());
					hero.ActionsPipeline.AddTask(onTurnEndTaskDamageTask);
					break;
				case EAbilityType.OnAttackNoBackDamage:
					hero.ActionsPipeline.AddTask(_container.Instantiate<DealDamageTask>());
					break;
				case EAbilityType.BeforeAttackWrongTargetChance:
					hero.ActionsPipeline.AddTask(_container.Instantiate<HeroWrongTargetChanceTask>());
					hero.ActionsPipeline.AddTask(_container.Instantiate<DealDamageTask>());
					break;
				case EAbilityType.AfterAttackLifeStealChance:
					hero.ActionsPipeline.AddTask(_container.Instantiate<DealDamageTask>());
					hero.ActionsPipeline.AddTask(_container.Instantiate<HeroLifeStealChanceTask>());
					break;
				case EAbilityType.OnDamagedHolyShield:
					hero.HasHolyShield = true;
					hero.ActionsPipeline.AddTask(_container.Instantiate<DealDamageTask>());
					//hero.ActionsPipeline.AddTask(new OnDamagedTask());
					break;
				case EAbilityType.AfterAttackFreezeTarget:
					hero.ActionsPipeline.AddTask(_container.Instantiate<DealDamageTask>());
					hero.ActionsPipeline.AddTask(_container.Instantiate<AfterAttackFreezeTargetTask>());
					break;
				case EAbilityType.OnTurnEndAllyHeal:
					hero.ActionsPipeline.AddTask(_container.Instantiate<DealDamageTask>());

					hero.TurnEndPipeline.AddTask(_container.Instantiate<OnTurnEndHealTask>());
					break;
				case EAbilityType.OnDamagedDealDamageToAll:
					hero.ActionsPipeline.AddTask(_container.Instantiate<DealDamageTask>());
					break;
				default:
					throw new ArgumentOutOfRangeException($"{config.AbilityType} is not supported");
			}

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