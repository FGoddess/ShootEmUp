using Core.Hero;
using Core.Services;
using UnityEngine;

namespace Core.Tasks.Hero
{
public class OnTurnEndDamageTask : EventTask
{
	private HeroData _heroData;

	private readonly PlayerService _playerService;


	public OnTurnEndDamageTask(PlayerService playerService)
	{
		_playerService = playerService;
	}

	public void SetHero(HeroData heroData)
	{
		_heroData = heroData;
	}

	protected override void OnStart()
	{
		Debug.Log($"{_heroData.Config.name}: OnTurnEndTaskDamageTask Started");
		
		var randEnemy = _heroData.IsBlueTeam
			? _playerService.RedPlayerHeroes[Random.Range(0, _playerService.RedPlayerHeroes.Count)]
			: _playerService.BluePlayerHeroes[Random.Range(0, _playerService.BluePlayerHeroes.Count)];

		randEnemy.ChangeHealth(-_playerService.SelectedAttacker.Config.Damage);
		randEnemy.View.SetStats($"{randEnemy.Config.Damage}/{randEnemy.Health}");

		Complete();
	}

	protected override void OnComplete()
	{
		Debug.Log($"{_heroData.Config.name}: OnTurnEndTaskDamageTask Completed");
	}
}
}