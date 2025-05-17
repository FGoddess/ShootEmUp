using Configs;
using UnityEngine;
using Zenject;

namespace DI
{
[CreateAssetMenu(menuName = "ConfigsInstaller", fileName = "ConfigsInstaller")]
public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
{
	[SerializeField]
	private HeroesConfig _heroesConfig;
	
	public override void InstallBindings()
	{
		Container.Bind<HeroesConfig>().FromInstance(_heroesConfig);
	}
}
}