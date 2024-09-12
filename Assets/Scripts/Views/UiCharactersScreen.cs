using System;
using System.Collections.Generic;
using Managers;
using Sirenix.OdinInspector;
using UnityEngine;
using Utils;
using Zenject;

namespace Views
{
public class UiCharactersScreen : MonoBehaviour, IInitializable, IDisposable
{
	[SerializeField]
	private CharacterButton _buttonPrefab;

	[ShowInInspector]
	private CharactersManager _charactersManager;

	private readonly List<CharacterButton> _charactersButtons = new();

	[Inject]
	public void Construct(CharactersManager charactersManager)
	{
		_charactersManager = charactersManager;
	}

	public void Initialize()
	{
		for (var i = 0; i < _charactersManager.CharacterCount; i++)
		{
			var characterButton = Instantiate(_buttonPrefab, transform);
			_charactersButtons.Add(characterButton);
			int id = i;

			characterButton.Button.onClick.AddListener(() => _charactersManager.ShowCharacterPopup(id));
			characterButton.SetText($"Character {id + 1}");
		}
	}

	public void Dispose()
	{
		foreach (var button in _charactersButtons)
			button.Button.onClick.RemoveAllListeners();
	}
}
}