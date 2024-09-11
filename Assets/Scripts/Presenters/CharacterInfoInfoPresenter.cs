using Models;
using Presenters.Interfaces;
using Views;
using CharacterInfo = Models.CharacterInfo;

namespace Presenters
{
public class CharacterInfoInfoPresenter : ICharacterInfoPresenter
{
	public CharacterStat[] Stats { get; }


	public CharacterInfoInfoPresenter(CharacterInfo characterInfo, CharacterInfoView view)
	{
		Stats = characterInfo.GetStats();
	}
}
}