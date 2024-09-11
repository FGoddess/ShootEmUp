using Models;

namespace Presenters.Interfaces
{
public interface ICharacterInfoPresenter : IPresenter
{
	public CharacterStat[] Stats { get; }
}
}