namespace Rewards.Interfaces
{
public interface IRewardVisitor
{
	void Visit(SoftMoneyReward reward);
	void Visit(HardMoneyReward reward);
}
}