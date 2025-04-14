using Entitas;
using Factory;
using Types;

namespace Systems
{
public class CreateBaseSystem : IInitializeSystem
{
	private readonly Contexts _contexts;

	private readonly IBaseViewFactory _factory;

	public CreateBaseSystem(Contexts contexts, IBaseViewFactory baseFactory)
	{
		_contexts = contexts;
		_factory  = baseFactory;
	}

	public void Initialize()
	{
		CreateBase(ETeamColor.Blue);
		CreateBase(ETeamColor.Red);
	}

	private void CreateBase(ETeamColor color)
	{
		var entity = _contexts.game.CreateEntity();
		entity.AddHealth(1000);
		entity.AddTeamTag(color);
		entity.AddSizeRadius(3.5f);

		var view = _factory.CreateView(entity, color);

		entity.AddPosition(view.transform.position);
	}
}
}