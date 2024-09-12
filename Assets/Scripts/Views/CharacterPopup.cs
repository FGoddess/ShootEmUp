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

	[Inject]
	private UserInfoView _userInfoView;
	[Inject]
	private PlayerLevelView _playerLevelView;
	[Inject]
	private CharacterInfoView _characterInfoView;


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