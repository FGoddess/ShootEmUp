using System.Collections.Generic;

namespace Core.Services
{
public class PlayerService
{
	public List<Hero> BluePlayerHeroes;
	public List<Hero> RedPlayerHeroes;

	public bool IsBluePlayerTurn { get; private set; } = true;

	public void SetNextPlayerTurn()
	{
		IsBluePlayerTurn = !IsBluePlayerTurn;
	}
}
}