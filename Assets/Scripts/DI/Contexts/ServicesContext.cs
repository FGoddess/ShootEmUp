using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace DI.Contexts
{
public class ServicesContext : IServicesContext, IInitializable
{
	private readonly Dictionary<Type, object> _services = new();
	private readonly DiContainer              _container;

	public ServicesContext(DiContainer container)
	{
		_container = container;
	}

	public void Initialize()
	{
		foreach (var service in _container.ResolveAll<IGameService>())
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