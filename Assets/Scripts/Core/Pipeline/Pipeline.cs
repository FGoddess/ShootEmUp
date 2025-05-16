using System;
using System.Collections.Generic;
using Core.Tasks;

namespace Core
{
public abstract class Pipeline
{
	public event Action OnCompleted;

	private readonly List<EventTask> _tasks = new();

	private int _taskIndex = -1;


	public void AddTask(EventTask task)
	{
		_tasks.Add(task);
	}

	public void ClearAllTasks()
	{
		_tasks.Clear();
	}

	public void ResetIndex()
	{
		_taskIndex = -1;
	}

	public void StartNextTask()
	{
		_taskIndex++;

		if (_taskIndex >= _tasks.Count)
		{
			OnCompleted?.Invoke();
			return;
		}

		_tasks[_taskIndex].Start(OnTaskFinished);
	}

	private void OnTaskFinished()
	{
		StartNextTask();
	}
}
}