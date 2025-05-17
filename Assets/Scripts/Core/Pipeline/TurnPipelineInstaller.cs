using Core.Tasks;
using Zenject;

namespace Core
{
public class TurnPipelineInstaller : IInitializable
{
	private readonly TurnPipeline _pipeline;
	private readonly DiContainer  _container;

	public TurnPipelineInstaller(TurnPipeline pipeline, DiContainer container)
	{
		_pipeline  = pipeline;
		_container = container;
	}

	public void Initialize()
	{
		_pipeline.AddTask(_container.Resolve<SelectHeroTask>());
		_pipeline.AddTask(_container.Resolve<SelectTargetTask>());
	}
}
}