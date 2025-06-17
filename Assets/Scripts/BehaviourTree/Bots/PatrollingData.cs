using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace BehaviourTree.Bots
{
public class PatrollingData : MonoBehaviour
{
	[SerializeField] private float       _waitTime = 2f;
	[SerializeField] private Transform[] _patrolPoints;

	private Bot _bot;

	private Transform _currentPatrol;
	private Transform _previousPatrol;
	private float     _waitUntilTime;


	[Inject]
	public void Construct(Bot bot)
	{
		_bot = bot;

		_currentPatrol = _patrolPoints[0];
	}

	public void UpdateFromNode()
	{
		if (_waitUntilTime > Time.time)
			return;

		_bot.PlayerMover.DoMove(_currentPatrol);

		var dist = _currentPatrol.position - transform.position;

		if (dist.sqrMagnitude > 0.1f)
			return;

		_waitUntilTime = _waitTime + Time.time;

		UpdatePatrol();
	}

	private void UpdatePatrol()
	{
		_previousPatrol = _currentPatrol;

		while (_currentPatrol == _previousPatrol)
			_currentPatrol = _patrolPoints[Random.Range(0, _patrolPoints.Length)];
	}
}
}