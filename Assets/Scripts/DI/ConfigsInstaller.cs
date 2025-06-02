using UnityEngine;
using Zenject;

namespace DI
{
[CreateAssetMenu(menuName = "Installers/ConfigsInstaller", fileName = "ConfigsInstaller")]
public class ConfigsInstaller : ScriptableObjectInstaller<ConfigsInstaller>
{
	public override void InstallBindings() { }
}
}