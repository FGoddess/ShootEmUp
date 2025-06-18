using DI.Signals;
using TutorialHW.UI;
using UnityEngine;
using Zenject;

namespace TutorialHW.Controllers
{
public abstract class TutorialStepController : MonoBehaviour
{
	protected TutorialCursor       TutorialCursor;
	protected TutorialHintsService TutorialHintsService;

	private SignalBus _signalBus;

	protected abstract TutorialStep Step { get; }


	[Inject]
	private void Construct(SignalBus signalBus, TutorialCursor tutorialCursor, TutorialHintsService tutorialHintsService)
	{
		_signalBus = signalBus;

		TutorialCursor       = tutorialCursor;
		TutorialHintsService = tutorialHintsService;
	}

	public void TryStartStep(StepStartedSignal signal)
	{
		if (signal.Step != Step)
			return;

		OnStepStarted();
	}

	public abstract void OnStepStarted();

	protected virtual void CompleteStep()
	{
		_signalBus.Fire<StepFinishSignal>();
	}
}
}