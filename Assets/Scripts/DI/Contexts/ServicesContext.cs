using System;
using System.Collections.Generic;
using UnityEngine;

namespace DI.Contexts
{
public class ServicesContext
{
	private readonly Dictionary<Type, object> _services = new();

	private ServicesContext(List<IGameService> services)
	{
		foreach (var service in services)
			RegisterService(service);
	}

	private void RegisterService<T>(T service)
	{
		var serviceType = service.GetType();
		_services[serviceType] = service;
	}

	public T GetService<T>()
	{
		return (T)_services[typeof(T)];
	}

	public bool TryRemoveService<T>()
	{
		return _services.Remove(typeof(T));
	}
}
}