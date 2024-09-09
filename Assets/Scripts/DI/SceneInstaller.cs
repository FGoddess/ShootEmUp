using Bullets;
using Character;
using Common;
using Components;
using Controllers;
using Enemy;
using Enemy.Agents;
using Game;
using Input;
using Level;
using UnityEngine;
using Zenject;

namespace DI
{
public class SceneInstaller : MonoInstaller
{
	[SerializeField]
	private MoveComponent _moveComponent;
	[SerializeField]
	private HitPointsComponent _hitPointsComponent;
	[SerializeField]
	private WeaponComponent _weaponComponent;

	[SerializeField]
	private Transform _enemyContainer;
	[SerializeField]
	private Transform _bulletContainer;
	[SerializeField]
	private Transform _worldTransform;
	[SerializeField]
	private EnemyAgent _enemyPrefab;
	[SerializeField]
	private Bullet _bulletPrefab;
	[SerializeField]
	private int _initialCount = 10;
	[SerializeField]
	private int _maxActiveEnemiesCount = 7;


	public override void InstallBindings()
	{
		InstallGameSystems();
		InstallFactories();
		InstallControllers();
		InstallCharacter();
		InstallUi();
	}

	private void InstallGameSystems()
	{
		Container.BindInterfacesAndSelfTo<GameStartup>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<InputManager>().AsSingle().NonLazy();

		Container.BindInterfacesAndSelfTo<BulletSetupSystem>().AsSingle();

		Container.BindInterfacesAndSelfTo<EnemyPositions>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<EnemySetupSystem>().AsSingle();
		Container.BindInterfacesAndSelfTo<EnemyUpdateSystem>().AsSingle().NonLazy();
		
		Container.BindInterfacesAndSelfTo<LevelBounds>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<LevelBackground>().FromComponentInHierarchy().AsSingle();
	}

	private void InstallFactories()
	{
		Container.Bind<Transform>().WithId(DiHelper.ENEMY_CONTAINER).FromInstance(_enemyContainer);
		Container.Bind<Transform>().WithId(DiHelper.BULLET_CONTAINER).FromInstance(_bulletContainer);
		Container.Bind<Transform>().WithId(DiHelper.WORLD_TRANSFORM).FromInstance(_worldTransform);

		Container.Bind<EnemyAgent>().FromInstance(_enemyPrefab);
		Container.Bind<EnemyFactory>().AsSingle();

		Container.Bind<Bullet>().FromInstance(_bulletPrefab);
		Container.Bind<BulletFactory>().AsSingle();
		
		Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle().WithArguments(_initialCount, _maxActiveEnemiesCount);
		Container.BindInterfacesAndSelfTo<BulletSystem>().AsSingle().WithArguments(_initialCount);
	}

	private void InstallControllers()
	{
		Container.BindInterfacesAndSelfTo<GamePauseController>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<GameStartController>().AsSingle().NonLazy();

		Container.BindInterfacesAndSelfTo<WeaponController>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<MoveController>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<InputController>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<GameEndController>().AsSingle();

		Container.BindInterfacesAndSelfTo<EnemySetupController>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<EnemyFireController>().AsSingle();
	}

	private void InstallCharacter()
	{
		Container.BindInterfacesAndSelfTo<CharacterAgent>().AsSingle();
		Container.BindInterfacesAndSelfTo<MoveComponent>().FromInstance(_moveComponent).AsSingle();
		Container.BindInterfacesAndSelfTo<HitPointsComponent>().FromInstance(_hitPointsComponent).AsSingle();
		Container.BindInterfacesAndSelfTo<WeaponComponent>().FromInstance(_weaponComponent).AsSingle();
	}

	private void InstallUi()
	{
		Container.BindInterfacesAndSelfTo<UiStartScreen>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<UiPauseScreen>().FromComponentInHierarchy().AsSingle();
	}
}
}