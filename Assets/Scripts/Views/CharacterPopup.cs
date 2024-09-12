using System;
using Presenters;
using Presenters.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Views
{
public class CharacterPopup : MonoBehaviour
{
	[SerializeField]
	private Button _closeButton;
	
	private UserInfoView _userInfoView;
	private PlayerLevelView _playerLevelView;
	private CharacterInfoView _characterInfoView;


	[Inject]
	private void Construct(UserInfoView userInfoView, PlayerLevelView playerLevelView, CharacterInfoView characterInfoView)
	{
		_userInfoView      = userInfoView;
		_playerLevelView   = playerLevelView;
		_characterInfoView = characterInfoView;
	}

	private void Awake()
	{
		_closeButton.onClick.AddListener(Hide);
	}

	public void Show(IPresenter[] presenters)
	{
		gameObject.SetActive(true);
		
		foreach (var presenter in presenters)
			switch (presenter)
			{
				case CharacterInfoPresenter characterInfoPresenter:
					_characterInfoView.Show(characterInfoPresenter);
					break;
				case UserInfoPresenter userInfoPresenter:
					_userInfoView.Show(userInfoPresenter);
					break;
				case PlayerLevelPresenter playerLevelPresenter:
					_playerLevelView.Show(playerLevelPresenter);
					break;
				default:
					throw new ArgumentOutOfRangeException($"{presenter} is not supported");
			}
	}

	private void Hide()
	{
		_userInfoView.Hide();
		_playerLevelView.Hide();
		_characterInfoView.Hide();
	}

	private void OnDestroy()
	{
		_closeButton.onClick.RemoveAllListeners();
	}
}
}