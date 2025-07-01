using DI.Contexts;

namespace Rewards.Interfaces
{
public interface IReward
{
	void Apply(IServicesContext servicesContext);
	string GetDescription();
}
}