using Core.Services;
using Core.Tasks;
using UnityEngine;

namespace Core
{
public class StartHeroesTurnEndPipelineTask : EventTask
{
	private readonly PlayerService _playerService;


	public StartHeroesTurnEndPipelineTask(PlayerService playerService)
	{
		_playerService = playerService;
	}

	protected override void OnStart()
	{
		Debug.Log("StartHeroesTurnEndPipelineTask start");

		foreach (var hero in _playerService.CurrentPlayerHeroes)
			hero.TurnEndPipeline.StartNextTask();

		Complete();
	}

	protected override void OnComplete()
	{
		foreach (var hero in _playerService.CurrentPlayerHeroes)
			hero.TurnEndPipeline.ResetIndex();
		
		Debug.Log("StartHeroesTurnEndPipelineTask complete");
	}
}
}