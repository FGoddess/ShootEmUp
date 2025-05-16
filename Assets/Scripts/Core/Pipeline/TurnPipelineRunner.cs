using UnityEngine;
using Zenject;

namespace Core
{
public class TurnPipelineRunner : IInitializable, ITickable
{
	private TurnPipeline _pipeline;


	[Inject]
	public void Construct(TurnPipeline pipeline)
	{
		_pipeline = pipeline;
	}

	public void Initialize()
	{
		_pipeline.OnCompleted += OnTurnCompleted;
		StartNextTask();
	}

	private void OnTurnCompleted()
	{
		_pipeline.ResetIndex();
	}

	private void StartNextTask()
	{
		_pipeline.StartNextTask();
	}

	public void Tick()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			StartNextTask();
	}
}
}