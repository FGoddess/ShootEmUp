using Core.Tasks;
using Zenject;

namespace Core
{
public class TurnPipelineInstaller : IInitializable
{
	private TurnPipeline _pipeline;
	private DiContainer  _container;
	private SignalBus    _signalBus;

	[Inject]
	public void Construct(TurnPipeline pipeline, DiContainer container, SignalBus signalBus)
	{
		_pipeline  = pipeline;
		_container = container;
		_signalBus = signalBus;
	}

	public void Initialize()
	{
		_pipeline.AddTask(_container.Resolve<SelectHeroTask>());
		_pipeline.AddTask(_container.Resolve<DealDamageTask>());
	}
}
}