using Chests.Configs;
using UnityEngine;
using Zenject;

namespace DI
{
[CreateAssetMenu(fileName = "ConfigsInstaller", menuName = "DI/ConfigsInstaller")]
public class ConfigsInstaller : ScriptableObjectInstaller
{
	[SerializeField] private ChestConfig[] _chestConfigs;

	public override void InstallBindings()
	{
		Container.BindInstance(_chestConfigs).AsCached();

		Container.Bind<ChestConfigsList>().AsSingle();
	}
}
}