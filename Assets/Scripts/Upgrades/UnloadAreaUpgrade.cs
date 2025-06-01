using Comps;
using Configs;
using Zenject;

namespace Upgrades
{
public class UnloadAreaUpgrade : UpgradeBase
{
	private UnloadAreaComp _unloadAreaComp;

	private readonly UnloadAreaConfig _config;

	public UnloadAreaUpgrade(UpgradeConfig config) : base(config)
	{
		_config = (UnloadAreaConfig)config;
	}
	
	[Inject]
	private void Construct(UnloadAreaComp unloadAreaComp)
	{
		_unloadAreaComp = unloadAreaComp;
	}

	protected override void OnUpgrade(int level)
	{
		SetLevel(level);
	}

	private void SetLevel(int level)
	{
		_unloadAreaComp.Set(_config.AreaUpgradesConfig.GetCapacity(level));
	}
}
}