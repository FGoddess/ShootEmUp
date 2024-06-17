using Bullets;
using Components;
using Enemy.Agents;
using ShootEmUp;
using UnityEngine;

namespace Enemy
{
public class EnemySetupSystem : MonoBehaviour
{
	[SerializeField]
	private BulletSystem _bulletSystem;
	
	/*public void Setup(EnemyAgent enemy)
	{
		enemy.OnFire -= OnFire;
	}*/
}
}