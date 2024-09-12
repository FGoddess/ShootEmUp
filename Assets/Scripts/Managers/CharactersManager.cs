using System;
using System.Collections.Generic;
using Configs;
using Helpers;
using Presenters;
using Sirenix.OdinInspector;
using Views;

namespace Managers
{
[Serializable]
public class CharactersManager
{
	[ShowInInspector]
	private CharacterCreator _currentCreator;

	private readonly CharacterPopup         _characterPopup;
	private readonly List<CharacterCreator> _characterHelpers = new();

	public int CharacterCount => _characterHelpers.Count;

	public CharactersManager(ConfigCharacters configCharacters, CharacterPresenterFactory factory, CharacterPopup characterPopup)
	{
		_characterPopup = characterPopup;

		foreach (var configCharacter in configCharacters.Characters)
		{
			var characterHelper = new CharacterCreator(configCharacter, factory);
			_characterHelpers.Add(characterHelper);
		}
	}

	public void ShowCharacterPopup(int id)
	{
		_currentCreator = _characterHelpers[id];
		_characterPopup.Show(_currentCreator.CreatePresenters());
	}
}
}