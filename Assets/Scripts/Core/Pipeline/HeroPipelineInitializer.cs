using Core.Tasks;
using Core.Tasks.Hero;
using Zenject;

namespace Core
{
public class HeroPipelineInitializer : IInitializable
{
	private readonly DiContainer _container;

	public HeroPipelineInitializer(DiContainer container)
	{
		_container = container;
	}

	public void Initialize()
	{
		//_pipeline.AddTask(_container.Instantiate<AfterAttackTask>());
	}
}
}