using UniRx;

namespace Presenters.Interfaces
{
public interface ICharacterStatPresenter : IPresenter
{
	public string                        Name  { get; }
	public ReadOnlyReactiveProperty<int> Value { get; }
}
}