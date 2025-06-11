using DI.Contexts;

namespace Money
{
public class MoneyService : IGameService
{
	public int SoftMoney { get; private set; }
	public int HardMoney { get; private set; }

	
	public void ChangeSoft(int delta)
	{
		SoftMoney += delta;
	}

	public void ChangeHard(int delta)
	{
		HardMoney += delta;
	}
}
}