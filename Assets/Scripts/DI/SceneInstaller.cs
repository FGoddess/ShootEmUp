using Presenters;
using Zenject;

namespace DI
{
public class SceneInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<CharacterPresenterFactory>().AsSingle();
	}
}
}