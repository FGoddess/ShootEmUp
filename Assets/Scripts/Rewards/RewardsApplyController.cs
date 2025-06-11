using Money;
using Rewards.Interfaces;

namespace Rewards
{
public class RewardsApplyController : IRewardVisitor
{
	private readonly MoneyService _moneyService;

	public RewardsApplyController(MoneyService moneyService)
	{
		_moneyService = moneyService;
	}

	public void Visit(SoftMoneyReward reward)
	{
		_moneyService.ChangeSoft(reward.SoftMoneyAmount);
	}

	public void Visit(HardMoneyReward reward)
	{
		_moneyService.ChangeHard(reward.HardMoneyAmount);
	}
}
}