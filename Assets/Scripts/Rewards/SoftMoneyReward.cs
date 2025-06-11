using System;
using Rewards.Interfaces;

namespace Rewards
{
[Serializable]
public struct SoftMoneyReward : IReward
{
	public int SoftMoneyAmount;

	public void Accept(IRewardVisitor visitor)
	{
		visitor.Visit(this);
	}
}
}