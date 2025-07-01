using DI.Contexts;
using UniRx;

namespace Money
{
public class MoneyService : IGameService
{
	private ReactiveProperty<int> SoftMoney { get; } = new();
	private ReactiveProperty<int> HardMoney { get; } = new();

	public void ChangeSoft(int value)
	{
		SoftMoney.Value += value;
	}

	public void ChangeHard(int value)
	{
		HardMoney.Value += value;
	}
}
}