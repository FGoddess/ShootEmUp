using System.Collections.Generic;
using UnityEngine;

namespace Common
{
public abstract class ObjectPool<T> where T : MonoBehaviour
{
	private readonly T         _prefab;
	private readonly Transform _container;

	private readonly Queue<T> _pool = new();


	protected ObjectPool(T prefab, Transform container, int initialCount)
	{
		_prefab       = prefab;
		_container    = container;
		
		for (var i = 0; i < initialCount; i++)
		{
			var obj = Object.Instantiate(_prefab, _container);
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

		obj = Object.Instantiate(_prefab, container);
		return obj;
	}

	public void ReturnToPool(T obj)
	{
		obj.transform.SetParent(_container);
		_pool.Enqueue(obj);
	}
}
}