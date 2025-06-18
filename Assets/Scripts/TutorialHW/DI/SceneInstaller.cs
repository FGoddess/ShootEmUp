using DI.Signals;
using TutorialHW;
using TutorialHW.Controllers;
using TutorialHW.UI;
using Zenject;

namespace DI
{
public class SceneInstaller : MonoInstaller<SceneInstaller>
{
	public override void InstallBindings()
	{
		Container.BindInterfacesAndSelfTo<TutorialManager>().AsSingle();
		Container.BindInterfacesAndSelfTo<TutorialCursor>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<TutorialHintsService>().FromComponentInHierarchy().AsSingle();

		Container.Bind<StartStepController>().FromComponentInHierarchy().AsSingle();
		Container.Bind<ResAddToConveyorStepController>().FromComponentInHierarchy().AsSingle();
		Container.Bind<WaitForNewResController>().FromComponentInHierarchy().AsSingle();
		Container.Bind<TakeNewResController>().FromComponentInHierarchy().AsSingle();
		Container.Bind<OpenConveyorPopupController>().FromComponentInHierarchy().AsSingle();
		Container.Bind<UpgradeConveyorController>().FromComponentInHierarchy().AsSingle();

		Container.Bind<PopupInfoView>().FromComponentInHierarchy().AsSingle();

		InstallSignals();
	}

	private void InstallSignals()
	{
		SignalBusInstaller.Install(Container);

		Container.DeclareSignal<StepStartedSignal>();
		Container.DeclareSignal<StepFinishSignal>();
		Container.DeclareSignal<TutorialCompletedSignal>();

		Container.BindSignal<StepStartedSignal>().ToMethod<StartStepController>(x => x.TryStartStep).FromResolve();
		Container.BindSignal<StepStartedSignal>().ToMethod<ResAddToConveyorStepController>(x => x.TryStartStep).FromResolve();
		Container.BindSignal<StepStartedSignal>().ToMethod<WaitForNewResController>(x => x.TryStartStep).FromResolve();
		Container.BindSignal<StepStartedSignal>().ToMethod<TakeNewResController>(x => x.TryStartStep).FromResolve();
		Container.BindSignal<StepStartedSignal>().ToMethod<OpenConveyorPopupController>(x => x.TryStartStep).FromResolve();
		Container.BindSignal<StepStartedSignal>().ToMethod<UpgradeConveyorController>(x => x.TryStartStep).FromResolve();

		Container.BindSignal<TutorialCompletedSignal>().ToMethod<TutorialHintsService>(x => x.OnTutorialCompleted).FromResolve();
	}
}
}