using System.Collections.Generic;
using Configs;
using Models;
using Presenters;
using Sirenix.OdinInspector;
using UnityEngine;
using Views;
using Zenject;
using CharacterInfo = Models.CharacterInfo;

namespace Helpers
{
public class CharacterHelper : MonoBehaviour
{
	[SerializeField]
	private ConfigCharacter _configCharacter;
	[SerializeField]
	private CharacterInfoView _characterInfoView;
	[SerializeField]
	private UserInfoView _userInfoView;
	[SerializeField]
	private PlayerLevelView _playerLevelView;


	[SerializeField]
	private UserInfo _userInfo;
	[SerializeField]
	private CharacterInfo _characterInfo;
	[SerializeField]
	private PlayerLevel _playerLevel;

	private CharacterPresenterFactory _characterPresenterFactory;


	[Inject]
	private void Construct(CharacterPresenterFactory characterPresenterFactory)
	{
		_characterPresenterFactory = characterPresenterFactory;
	}

	[Button]
	public void PopupShow()
	{
		var stats = new HashSet<CharacterStat>();

		foreach (var pair in _configCharacter.StatsToValue)
			stats.Add(new CharacterStat(pair.Key, pair.Value));

		_userInfo      = new UserInfo(_configCharacter.Nickname, _configCharacter.Description, _configCharacter.Icon);
		_characterInfo = new CharacterInfo(stats);
		_playerLevel   = new PlayerLevel(_configCharacter.ExperienceCurrent);

		var presenter            = _characterPresenterFactory.CreateCharacter(_characterInfo, _characterInfoView);
		var userPresenter        = _characterPresenterFactory.CreateUser(_userInfo, _userInfoView);
		var playerLevelPresenter = _characterPresenterFactory.CreatePlayer(_playerLevel, _playerLevelView);

		_characterInfoView.Show(presenter);
		_userInfoView.Show(userPresenter);
		_playerLevelView.Show(playerLevelPresenter);
	}
}
}