using UnityEngine;

namespace Components
{
[RequireComponent(typeof(Rigidbody2D))]
public sealed class MoveComponent : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D _rigidbody2D;
	
	[SerializeField]
	private float _speed = 5.0f;


	public void MoveByRigidbodyVelocity(Vector2 vector)
	{
		var nextPosition = _rigidbody2D.position + vector * (_speed * Time.fixedDeltaTime);
		_rigidbody2D.MovePosition(nextPosition);
	}
}
}