using System;
using DI.Signals;
using UnityEngine;
using Zenject;

namespace TutorialHW
{
public class TutorialManager : IInitializable
{
	public bool         IsCompleted { get; private set; }
	public TutorialStep CurrentStep { get; private set; } = TutorialStep.None;

	private readonly SignalBus _signalBus;

	public TutorialManager(SignalBus signalBus)
	{
		_signalBus = signalBus;
		_signalBus.Subscribe<StepFinishSignal>(() => FinishStep());
	}

	public void Initialize()
	{
		StartNextStep();
	}

	private void StartNextStep()
	{
		CurrentStep++;

		Debug.Log($"Current step is {CurrentStep}");

		if (CurrentStep is not TutorialStep.Complete)
		{
			_signalBus.Fire(new StepStartedSignal(CurrentStep));
			return;
		}

		IsCompleted = true;
		_signalBus.Fire(new TutorialCompletedSignal());
	}

	private void FinishStep(bool moveNext = true)
	{
		//мне не пригодился, но в теории нужен будет
		//_signalBus.Fire(new StepCompletedSignal(CurrentStep));

		if (moveNext)
			StartNextStep();
	}
}
}