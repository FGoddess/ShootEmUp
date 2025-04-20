using Factory;
using UnityEngine;

namespace Systems.Features
{
public sealed class CreateSystems : Feature
{
	public CreateSystems(Contexts         contexts,
	                     IUnitViewFactory unitFactory,
	                     IBaseViewFactory baseFactory,
	                     IArrowFactory    arrowFactory)
	{
		Add(new CreateBaseSystem(contexts, baseFactory));
		Add(new CreateUnitSystem(contexts, unitFactory));
		Add(new CreateArrowSystem(contexts, arrowFactory));
	}
}
}