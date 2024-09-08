using Bullets;
using Character;
using Components;
using Controllers;
using Enemy;
using Game;
using Input;
using Level;
using Zenject;

namespace DI
{
public class SceneInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.BindInterfacesAndSelfTo<GameStartup>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<GameManager>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<InputManager>().AsSingle().NonLazy();
		

		Container.BindInterfacesAndSelfTo<BulletSystem>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<BulletSetupSystem>().AsSingle();

		Container.BindInterfacesAndSelfTo<EnemyPositions>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<EnemySpawner>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<EnemySetupSystem>().AsSingle();
		Container.BindInterfacesAndSelfTo<EnemyUpdateSystem>().AsSingle().NonLazy();
		
		Container.BindInterfacesAndSelfTo<CharacterAgent>().AsSingle();
		Container.BindInterfacesAndSelfTo<MoveComponent>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<HitPointsComponent>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<WeaponComponent>().FromComponentInHierarchy().AsSingle();


		Container.BindInterfacesAndSelfTo<LevelBackground>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<GamePauseController>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<GameStartController>().AsSingle().NonLazy();

		Container.BindInterfacesAndSelfTo<WeaponController>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<MoveController>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<InputController>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<GameEndController>().AsSingle();
		
		Container.BindInterfacesAndSelfTo<EnemySetupController>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<EnemyFireController>().AsSingle();

		Container.BindInterfacesAndSelfTo<UiStartScreen>().FromComponentInHierarchy().AsSingle();
		Container.BindInterfacesAndSelfTo<UiPauseScreen>().FromComponentInHierarchy().AsSingle();
	}
}
}