using Models;
using Presenters.Interfaces;
using Views;

namespace Presenters
{
public class CharacterStatPresenter : ICharacterStatPresenter
{
	public string Name  { get; }
	public int    Value { get; }

	private readonly CharacterStat     _characterStat;
	private readonly CharacterStatView _view;


	public CharacterStatPresenter(CharacterStat characterStat, CharacterStatView view)
	{
		_characterStat     = characterStat;
		_view = view;
		
		Name  = characterStat.Name;
		Value = characterStat.Value;
		
		characterStat.OnValueChanged += OnValueChanged;
	}

	private void OnValueChanged(int value)
	{
		_view.SetValue(value);
	}
}
}