namespace Core.Services
{
public class PlayerService
{
	public bool IsBluePlayerTurn { get; private set; } = true;

	public void SetNextPlayerTurn()
	{
		IsBluePlayerTurn = !IsBluePlayerTurn;
	}
}
}