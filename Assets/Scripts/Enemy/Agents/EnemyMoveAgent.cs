using Components;
using UnityEngine;

namespace Enemy.Agents
{
public class EnemyMoveAgent : MonoBehaviour
{
	[SerializeField]
	private MoveComponent _moveComponent;

	private Vector2 _destination;
	private bool    _isReached;

	private const float DESTINATION_TOLERANCE = 0.25f;

	public bool IsReached => _isReached;


	public void SetDestination(Vector2 endPoint)
	{
		_destination = endPoint;
		_isReached   = false;
	}

	public void UpdateMove()
	{
		var vector = _destination - (Vector2)transform.position;
		if (vector.magnitude <= DESTINATION_TOLERANCE)
		{
			_isReached = true;
			return;
		}

		var direction = vector.normalized;
		_moveComponent.MoveByRigidbodyVelocity(direction);
	}
}
}