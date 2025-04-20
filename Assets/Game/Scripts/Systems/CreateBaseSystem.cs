using Entitas;
using Factory;
using Types;
using UnityEngine;

namespace Systems
{
public class CreateBaseSystem : IInitializeSystem
{
	private readonly Contexts _contexts;
	private readonly IBaseViewFactory _factory;

	public CreateBaseSystem(Contexts contexts, IBaseViewFactory baseFactory)
	{
		_contexts = contexts;
		_factory = baseFactory;
	}

	public void Initialize()
	{
		CreateBase(ETeamColor.Blue);
		CreateBase(ETeamColor.Red);
	}

	private void CreateBase(ETeamColor color)
	{
		var entity = _contexts.game.CreateEntity();

		_factory.CreateView(entity, color);
	}
}
}