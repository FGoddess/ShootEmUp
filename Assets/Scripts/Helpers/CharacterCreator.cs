using System;
using System.Collections.Generic;
using Configs;
using Models;
using Presenters;
using Presenters.Interfaces;
using Sirenix.OdinInspector;

namespace Helpers
{
[Serializable]
public class CharacterCreator
{
	private readonly CharacterPresenterFactory _characterPresenterFactory;

	[ShowInInspector]
	private readonly UserInfo _userInfo;
	[ShowInInspector]
	private readonly CharacterInfo _characterInfo;
	[ShowInInspector]
	private readonly PlayerLevel _playerLevel;

	public CharacterCreator(ConfigCharacter configCharacter, CharacterPresenterFactory characterPresenterFactory)
	{
		_characterPresenterFactory = characterPresenterFactory;

		var stats = new HashSet<CharacterStat>();

		foreach (var pair in configCharacter.StatsToValue)
			stats.Add(new CharacterStat(pair.Key, pair.Value));

		_userInfo      = new UserInfo(configCharacter.Nickname, configCharacter.Description, configCharacter.Icon);
		_characterInfo = new CharacterInfo(stats);
		_playerLevel   = new PlayerLevel();
	}

	public IPresenter[] CreatePresenters()
	{
		var characterInfoPresenter = _characterPresenterFactory.Create(_characterInfo);
		var userPresenter          = _characterPresenterFactory.Create(_userInfo);
		var playerLevelPresenter   = _characterPresenterFactory.Create(_playerLevel);

		return new[] { userPresenter, playerLevelPresenter, characterInfoPresenter };
	}
}
}