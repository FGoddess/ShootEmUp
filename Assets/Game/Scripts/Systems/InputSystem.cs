using Entitas;
using Types;
using UnityEngine;

namespace Systems
{
public class InputSystem : IExecuteSystem
{
	private readonly GameContext _context;

	public InputSystem(Contexts contexts)
	{
		_context = contexts.game;
	}
	
	public void Execute()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
			Create(EUnitType.Swordsman, ETeamColor.Blue);

		if (Input.GetKeyDown(KeyCode.Alpha2))
			Create(EUnitType.Archer, ETeamColor.Blue);

		if (Input.GetKeyDown(KeyCode.Alpha3))
			Create(EUnitType.Swordsman, ETeamColor.Red);

		if (Input.GetKeyDown(KeyCode.Alpha4))
			Create(EUnitType.Archer, ETeamColor.Red);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Create(EUnitType.Archer, ETeamColor.Blue);
			Create(EUnitType.Archer, ETeamColor.Red);
		}
		
	}

	private void Create(EUnitType type, ETeamColor color)
	{
		var entity = _context.CreateEntity();
		entity.AddCreateUnitRequest(color, type);
	}
}
}