using Models;
using Presenters.Interfaces;
using Views;
using CharacterInfo = Models.CharacterInfo;

namespace Presenters
{
public class CharacterPresenterFactory
{
	public CharacterPresenterFactory()
	{
		
	}

	/*public ICharacterInfoPresenter CreateCharacter(CharacterInfo characterInfo)
	{
		return new CharacterInfoPresenter(characterInfo);
	}*/

	public IPresenter Create(UserInfo userInfo)
	{
		return new UserInfoPresenter(userInfo);
	}

	public IPresenter Create(PlayerLevel playerLevel)
	{
		return new PlayerLevelPresenter(playerLevel);
	}
}
}