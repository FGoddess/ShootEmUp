using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;
using Random = UnityEngine.Random;
using SceneContext = SceneInstallers.SceneContext;

namespace Enemy
{
public class EnemySpawnerInstaller : SceneEntityInstallerBase
{
	[SerializeField]
	private float _spawnInterval = 1f;
	[SerializeField]
	private SceneEntity _prefab;
	[SerializeField]
	private Transform[] _spawnPoints;

	public override void Install(IEntity entity)
	{
		var spawnTimer = new Timer(_spawnInterval, true);
		spawnTimer.OnEnded += () =>
		{
			var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
			var enemy      = Instantiate(_prefab, spawnPoint.position, Quaternion.identity, spawnPoint);
			enemy.AddTarget(SceneContext.Instance.GetPlayer().GetRoot());
		};
		
		entity.WhenUpdate(spawnTimer.Tick);
		spawnTimer.Play();
	}
}
}