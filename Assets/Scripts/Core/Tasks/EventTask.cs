using System;

namespace Core.Tasks
{
public abstract class EventTask
{
	private Action _onComplete;

	public void Start(Action onComplete)
	{
		_onComplete = onComplete;
		OnStart();
	}

	public void Complete()
	{
		OnComplete();
		_onComplete?.Invoke();
	}


	protected abstract void OnStart();
	protected abstract void OnComplete();
}
}