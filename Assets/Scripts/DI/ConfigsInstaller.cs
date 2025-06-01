using Configs;
using UnityEngine;
using Zenject;

namespace DI
{

[CreateAssetMenu(menuName = "Installers/ConfigsInstaller", fileName = "ConfigsInstaller")]
public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
{
	[SerializeField]
	private UpgradesConfig _upgradesConfig;
	
	public override void InstallBindings()
	{
		Container.Bind<UpgradesConfig>().FromInstance(_upgradesConfig);
	}
}
}