using Bullets;
using UnityEngine;

namespace DI
{
[CreateAssetMenu(fileName = "ScriptableObjectInstaller", menuName = "Installers/ScriptableObjectInstaller")]
public class ScriptableObjectInstaller : Zenject.ScriptableObjectInstaller<ScriptableObjectInstaller>
{
	[SerializeField]
	private BulletConfig _playerBulletConfig;
	[SerializeField]
	private BulletConfig _enemyBulletConfig;
	
	public override void InstallBindings()
	{
		Container.Bind<BulletConfig>().WithId("playerBulletConfig").FromInstance(_playerBulletConfig);
		Container.Bind<BulletConfig>().WithId("enemyBulletConfig").FromInstance(_enemyBulletConfig);
	}
}
}