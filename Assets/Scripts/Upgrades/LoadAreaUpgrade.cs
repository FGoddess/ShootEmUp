using Comps;
using Configs;
using Zenject;

namespace Upgrades
{
public class LoadAreaUpgrade : UpgradeBase
{
	private LoadAreaComp _loadAreaComp;

	private readonly LoadAreaConfig _config;

	public LoadAreaUpgrade(UpgradeConfig config) : base(config)
	{
		_config = (LoadAreaConfig)config;
	}
	
	[Inject]
	private void Construct(LoadAreaComp loadAreaComp)
	{
		_loadAreaComp = loadAreaComp;
	}

	protected override void OnUpgrade(int level)
	{
		SetLevel(level);
	}

	private void SetLevel(int level)
	{
		_loadAreaComp.Set(_config.AreaUpgradesConfig.GetCapacity(level));
	}
}
}