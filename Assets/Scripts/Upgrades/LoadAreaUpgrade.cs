using Components;
using Configs;
using Zenject;

namespace Upgrades
{
public class LoadAreaUpgrade : UpgradeBase
{
	private LoadAreaComponent _loadAreaComponent;

	private readonly LoadAreaConfig _config;

	public LoadAreaUpgrade(UpgradeConfig config) : base(config)
	{
		_config = (LoadAreaConfig)config;
	}
	
	[Inject]
	private void Construct(LoadAreaComponent loadAreaComponent)
	{
		_loadAreaComponent = loadAreaComponent;
	}

	protected override void OnUpgrade(int level)
	{
		SetLevel(level);
	}

	private void SetLevel(int level)
	{
		_loadAreaComponent.Set(_config.AreaUpgradesConfig.GetCapacity(level));
	}
}
}