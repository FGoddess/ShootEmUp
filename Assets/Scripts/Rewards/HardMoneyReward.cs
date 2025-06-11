using System;
using Rewards.Interfaces;

namespace Rewards
{
[Serializable]
public struct HardMoneyReward : IReward
{
	public int HardMoneyAmount;

	public void Accept(IRewardVisitor visitor)
	{
		visitor.Visit(this);
	}
}
}