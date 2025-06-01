namespace Money
{
public class MoneyService
{
	public int Money { get; private set; }

	public void AddMoney(int amount)
	{
		Money += amount;
	}

	public void SpendMoney(int amount)
	{
		Money -= amount;
	}

	public bool CanSpendMoney(int amount)
	{
		return Money >= amount;
	}
}
}