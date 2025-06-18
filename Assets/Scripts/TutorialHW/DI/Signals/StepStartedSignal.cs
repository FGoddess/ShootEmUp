using TutorialHW;

namespace DI.Signals
{
public class StepStartedSignal
{
	public TutorialStep Step { get; private set; }

	public StepStartedSignal(TutorialStep step)
	{
		Step = step;
	}
}
}