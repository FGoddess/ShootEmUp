using UnityEngine;

namespace BehaviourTree
{
public class PlayerMover : MonoBehaviour
{
	[SerializeField] private float _speed = 2f;

	public void DoMove(Transform target)
	{
		var dist = target.position - transform.position;
		dist.y             =  0;
		transform.position += dist.normalized * (_speed * Time.deltaTime);
	}
}
}