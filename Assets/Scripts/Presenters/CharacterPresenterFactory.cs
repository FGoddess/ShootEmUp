using Models;
using Presenters.Interfaces;
using Views;
using CharacterInfo = Models.CharacterInfo;

namespace Presenters
{
public class CharacterPresenterFactory
{
	public ICharacterInfoPresenter Create(CharacterInfo characterInfo)
	{
		return new CharacterInfoPresenter(characterInfo, this);
	}

	public IPresenter Create(UserInfo userInfo)
	{
		return new UserInfoPresenter(userInfo);
	}

	public IPresenter Create(CharacterStat characterStat)
	{
		return new CharacterStatPresenter(characterStat);
	}

	public IPresenter Create(PlayerLevel playerLevel)
	{
		return new PlayerLevelPresenter(playerLevel);
	}
}
}