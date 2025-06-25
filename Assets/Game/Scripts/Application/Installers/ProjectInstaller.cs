using UnityEngine;
using Zenject;

namespace SampleGame
{
[CreateAssetMenu(fileName = "ProjectInstaller", menuName = "Installers/New ProjectInstaller")]
public sealed class ProjectInstaller : ScriptableObjectInstaller
{
	[SerializeField] private ScenesConfig    _scenesConfig;
	[SerializeField] private LocationsConfig _locationsConfig;

	public override void InstallBindings()
	{
		Container.Bind<ApplicationExiter>().AsSingle().NonLazy();
		Container.Bind<GameLoader>().AsSingle().NonLazy();
		Container.Bind<MenuLoader>().AsSingle().NonLazy();
		Container.Bind<SceneLoader>().AsSingle().NonLazy();

		Container.BindInstance(_scenesConfig);
		Container.BindInstance(_locationsConfig);
	}
}
}