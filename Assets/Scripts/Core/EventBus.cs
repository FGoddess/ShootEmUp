using System;
using System.Collections.Generic;

namespace Core
{
public class EventBus : IEventBus
{
	private readonly Dictionary<Type, List<Delegate>> _handlers = new();

	public void RaiseEvent<T>(T evt)
	{
		var type = evt.GetType();

		if (!_handlers.TryGetValue(type, out var handlers))
			return;

		foreach (var handler in handlers)
		{
			var action = handler as Action<T>;
			action?.Invoke(evt);
		}
	}

	public void Subscribe<T>(Action<T> callback)
	{
		var type = typeof(T);

		if (!_handlers.ContainsKey(type))
			_handlers.Add(type, new List<Delegate>());

		_handlers[type].Add(callback);
	}

	public void Unsubscribe<T>(Action<T> callback)
	{
		var type = typeof(T);

		if (_handlers.TryGetValue(type, out var handler))
			handler.Remove(callback);
	}
}
}