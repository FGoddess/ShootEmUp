using Components;
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

		Container.Bind<LoadAreaComponent>().AsSingle();
		Container.Bind<UnloadAreaComponent>().AsSingle();
		Container.Bind<ProduceTimeComponent>().AsSingle();

		Container.Bind<ConveyorManager>().AsSingle();
	}
}
}