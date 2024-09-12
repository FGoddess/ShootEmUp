using UniRx;

namespace Presenters.Interfaces
{
public interface IPlayerLevelPresenter : IPresenter
{
	public ReadOnlyReactiveProperty<int>  Level              { get; }
	public ReadOnlyReactiveProperty<int>  CurrentExperience  { get; }
	public ReadOnlyReactiveProperty<int>  RequiredExperience { get; }
	public ReadOnlyReactiveProperty<bool> CanLevelUp         { get; }

	public ReactiveCommand LevelUpCommand { get; }
	public void LevelUp();
}
}