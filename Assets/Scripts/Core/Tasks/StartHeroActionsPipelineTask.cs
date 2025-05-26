using Core.Services;
using UnityEngine;

namespace Core.Tasks
{
public class StartHeroActionsPipelineTask : EventTask
{
	private readonly PlayerService _playerService;
	
	public StartHeroActionsPipelineTask(PlayerService playerService)
	{
		_playerService = playerService;
	}

	protected override void OnStart()
	{
		Debug.Log("StartHeroActionsTask start");

		_playerService.SelectedAttacker.ActionsPipeline.OnCompleted += Complete;
		_playerService.SelectedAttacker.ActionsPipeline.StartNextTask();
	}

	protected override void OnComplete()
	{
		_playerService.SelectedAttacker.ActionsPipeline.ResetIndex();
		_playerService.SelectedAttacker.ActionsPipeline.OnCompleted -= Complete;
		Debug.Log("StartHeroActionsTask complete");
	}
}
}