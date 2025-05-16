using System;
using UnityEngine;

namespace Core
{
public interface IEventBus
{
	void RaiseEvent<T>(T evt);

	void Subscribe<T>(Action<T>   callback);
	void Unsubscribe<T>(Action<T> callback);
}
}