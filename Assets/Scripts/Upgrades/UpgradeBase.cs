using Configs;
using UnityEngine;

namespace Upgrades
{
public abstract class UpgradeBase
{
	public EStatType Type           => _config.Type;
	public int       Level          { get; private set; }
	public bool      IsMaxLevel     => Level == _config.PricesByIdx.Length - 1;
	public int       NextLevelPrice => _config.GetPrice(Level + 1);

	private readonly UpgradeConfig _config;

	protected UpgradeBase(UpgradeConfig config)
	{
		_config = config;
	}

	public void IncreaseLevel()
	{
		Level++;
		OnUpgrade(Level);
		Debug.Log($"Set {Type} lvl: {Level}");
	}

	protected abstract void OnUpgrade(int level);
}
}