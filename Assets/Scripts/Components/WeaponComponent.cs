using System;
using UnityEngine;

namespace Components
{
public sealed class WeaponComponent : MonoBehaviour
{
	[SerializeField]
	private Transform _firePoint;

	public event Action<Vector2, Vector2> Fired;
	
	public Vector2 Position => _firePoint.position;
	public Quaternion Rotation => _firePoint.rotation;
	
	
	public void Fire(Vector2 direction)
	{
		Fired?.Invoke(transform.position, direction);
	}
}
}