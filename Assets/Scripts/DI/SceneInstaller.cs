using Comps;
using Conveyor;
using Money;
using Upgrades;
using Zenject;

namespace DI
{
public class SceneInstaller : MonoInstaller<SceneInstaller>
{
	public override void InstallBindings()
	{
		Container.BindInterfacesAndSelfTo<MoneyService>().AsSingle();
		Container.BindInterfacesAndSelfTo<UpgradesService>().AsSingle();

		Container.Bind<LoadAreaComp>().AsSingle();
		Container.Bind<UnloadAreaComp>().AsSingle();
		Container.Bind<ProduceTimeComp>().AsSingle();

		Container.Bind<ConveyorManager>().AsSingle();
	}
}
}