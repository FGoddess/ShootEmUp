namespace Rewards.Interfaces
{
public interface IReward
{
	void Accept(IRewardVisitor visitor);
}
}