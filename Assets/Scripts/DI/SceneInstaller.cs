using Hero;
using Inventory;
using Inventory.Controllers;
using Zenject;

namespace DI
{
public class SceneInstaller : MonoInstaller<SceneInstaller>
{
	public override void InstallBindings()
	{
		Container.BindInterfacesAndSelfTo<InventoryList>().AsSingle();

		Container.BindInterfacesAndSelfTo<HeroItemEffectsController>().AsSingle();

		Container.BindInterfacesAndSelfTo<HeroData>().AsSingle();
	}
}
}