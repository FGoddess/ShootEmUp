using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
public class ServiceContext
{
	private readonly List<object> _services;

	public ServiceContext(List<object> services)
	{
		_services = services;
	}

	public T GetService<T>()
	{
		for (var i = 0; i < _services.Count; i++)
			if (_services[i] is T result)
				return result;

		throw new Exception($"Service {typeof(T).Name} is not found!");
	}
}
}