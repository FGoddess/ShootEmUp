using Configs;
using UnityEngine;

namespace DI
{
[CreateAssetMenu(fileName = "ConfigsInstaller", menuName = "Installers/ConfigsInstaller")]
public class ConfigsInstaller : Zenject.ScriptableObjectInstaller<ConfigsInstaller>
{
	[SerializeField]
	private ConfigCharacters _configCharacters;

	public override void InstallBindings()
	{
		Container.Bind<ConfigCharacters>().FromInstance(_configCharacters).AsSingle();
	}
}
}