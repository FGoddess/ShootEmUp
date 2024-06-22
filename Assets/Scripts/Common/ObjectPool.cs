using System.Collections.Generic;
using UnityEngine;

namespace Common
{
public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
	[SerializeField]
	private T _prefab;
	[SerializeField]
	private Transform _container;
	[SerializeField]
	private Transform _worldTransform;
	[SerializeField]
	private int _initialCount;

	private readonly Queue<T> _pool = new();
	

	private void Awake()
	{
		for (var i = 0; i < _initialCount; i++)
		{
			var obj = Instantiate(_prefab, _container);
			_pool.Enqueue(obj);
		}
	}

	public T GetFromPool()
	{
		T obj;
		
		if (_pool.Count > 0)
		{
			obj = _pool.Dequeue();
			obj.transform.SetParent(_worldTransform);
			return obj;
		}

		obj = Instantiate(_prefab, _worldTransform);
		return obj;
	}

	public void ReturnToPool(T obj)
	{
		obj.transform.SetParent(_container);
		_pool.Enqueue(obj);
	}
}
}