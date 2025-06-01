using Comps;
using Configs;
using Zenject;

namespace Upgrades
{
public class ProduceTimeUpgrade : UpgradeBase
{
	private ProduceTimeComp _produceTimeComp;

	private readonly ProduceTimeConfig _config;

	public ProduceTimeUpgrade(UpgradeConfig config) : base(config)
	{
		_config = (ProduceTimeConfig)config;
	}

	[Inject]
	private void Construct(ProduceTimeComp produceTimeComp)
	{
		_produceTimeComp = produceTimeComp;
	}

	protected override void OnUpgrade(int level)
	{
		SetLevel(level);
	}

	private void SetLevel(int level)
	{
		_produceTimeComp.Set(_config.ProduceTimeUpgradesConfig.GetTime(level));
	}
}
}