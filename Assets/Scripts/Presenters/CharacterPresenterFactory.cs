using Models;
using Presenters.Interfaces;
using Views;
using CharacterInfo = Models.CharacterInfo;

namespace Presenters
{
public class CharacterPresenterFactory
{
	public CharacterPresenterFactory() { }

	public ICharacterInfoPresenter CreateCharacter(CharacterInfo characterInfo, CharacterInfoView view)
	{
		return new CharacterInfoInfoPresenter(characterInfo, view);
	}

	public IUserInfoPresenter CreateUser(UserInfo userInfo, UserInfoView view)
	{
		return new UserInfoPresenter(userInfo, view);
	}

	public IPlayerLevelPresenter CreatePlayer(PlayerLevel playerLevel, PlayerLevelView view)
	{
		return new PlayerLevelPresenter(playerLevel, view);
	}
}
}