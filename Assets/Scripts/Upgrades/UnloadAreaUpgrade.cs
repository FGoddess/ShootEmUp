using Components;
using Configs;
using Zenject;

namespace Upgrades
{
public class UnloadAreaUpgrade : UpgradeBase
{
	private UnloadAreaComponent _unloadAreaComponent;

	private readonly UnloadAreaConfig _config;

	public UnloadAreaUpgrade(UpgradeConfig config) : base(config)
	{
		_config = (UnloadAreaConfig)config;
	}
	
	[Inject]
	private void Construct(UnloadAreaComponent unloadAreaComponent)
	{
		_unloadAreaComponent = unloadAreaComponent;
	}

	protected override void OnUpgrade(int level)
	{
		SetLevel(level);
	}

	private void SetLevel(int level)
	{
		_unloadAreaComponent.Set(_config.AreaUpgradesConfig.GetCapacity(level));
	}
}
}