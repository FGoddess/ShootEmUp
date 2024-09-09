using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Common
{
public abstract class ObjectPool<T> where T : MonoBehaviour
{
	private readonly IFactory<Transform, T> _factory;
	private readonly Transform              _container;

	private readonly Queue<T> _pool = new();


	protected ObjectPool(IFactory<Transform, T> factory, Transform container, int initialCount)
	{
		_factory   = factory;
		_container = container;

		for (var i = 0; i < initialCount; i++)
		{
			var obj = _factory.Create(_container);
			obj.gameObject.SetActive(false);
			_pool.Enqueue(obj);
		}
	}

	public T GetFromPool(Transform container)
	{
		T obj;

		if (_pool.Count > 0)
		{
			obj = _pool.Dequeue();
			obj.transform.SetParent(container);
			return obj;
		}

		obj = _factory.Create(container);
		return obj;
	}

	public void ReturnToPool(T obj)
	{
		obj.gameObject.SetActive(false);
		obj.transform.SetParent(_container);
		_pool.Enqueue(obj);
	}
}
}