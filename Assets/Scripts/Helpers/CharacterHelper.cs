using System.Collections.Generic;
using Configs;
using Models;
using Presenters;
using Presenters.Interfaces;
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

	[Inject]
	private CharacterPopup _characterPopup;

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
		_playerLevel   = new PlayerLevel();

		//var presenter            = _characterPresenterFactory.CreateCharacter(_characterInfo);
		var userPresenter        = _characterPresenterFactory.Create(_userInfo);
		var playerLevelPresenter = _characterPresenterFactory.Create(_playerLevel);

		_characterPopup.Show(new[] { userPresenter, playerLevelPresenter });
	}
}
}