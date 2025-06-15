using Components;
using Configs;
using Zenject;

namespace Upgrades
{
public class ProduceTimeUpgrade : UpgradeBase
{
	private ProduceTimeComponent _produceTimeComponent;

	private readonly ProduceTimeConfig _config;

	public ProduceTimeUpgrade(UpgradeConfig config) : base(config)
	{
		_config = (ProduceTimeConfig)config;
	}

	[Inject]
	private void Construct(ProduceTimeComponent produceTimeComponent)
	{
		_produceTimeComponent = produceTimeComponent;
	}

	protected override void OnUpgrade(int level)
	{
		SetLevel(level);
	}

	private void SetLevel(int level)
	{
		_produceTimeComponent.Set(_config.ProduceTimeUpgradesConfig.GetTime(level));
	}
}
}