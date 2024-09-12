using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Utils
{
public sealed class LevelUpButton : MonoBehaviour
{
	[SerializeField] 
	private Button _button;

	[Space]
	[SerializeField] 
	private Image _buttonBackground;
	[SerializeField] 
	private Sprite _availableButtonSprite;
	[SerializeField] 
	private Sprite _lockedButtonSprite;

	[Space]
	[SerializeField]
	private LevelUpButtonState _state;
	

	public Button Button => _button;

	public void AddListener(UnityAction action)
	{
		Button.onClick.AddListener(action);
	}

	public void RemoveListener(UnityAction action)
	{
		Button.onClick.RemoveListener(action);
	}

	public void RemoveAllListeners()
	{
		Button.onClick.RemoveAllListeners();
	}

	public void SetAvailable(bool isAvailable)
	{
		var state = isAvailable ? LevelUpButtonState.Available : LevelUpButtonState.Locked;
		SetState(state);
	}

	public void SetState(LevelUpButtonState state)
	{
		_state = state;

		switch (state)
		{
			case LevelUpButtonState.Available:
				_buttonBackground.sprite = _availableButtonSprite;
				break;
			case LevelUpButtonState.Locked:
				_buttonBackground.sprite = _lockedButtonSprite;
				break;
			default:
				throw new Exception($"Undefined button state {state}!");
		}
	}
}
}