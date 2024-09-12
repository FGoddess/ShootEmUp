using System;
using Models;
using Presenters.Interfaces;
using UniRx;

namespace Presenters
{
public class CharacterStatPresenter : ICharacterStatPresenter, IDisposable
{
	public string                        Name  { get; }
	public ReadOnlyReactiveProperty<int> Value { get; }

	
	public CharacterStatPresenter(CharacterStat characterStat)
	{
		Name  = characterStat.Name;
		Value = new ReadOnlyReactiveProperty<int>(characterStat.Value);
	}
	
	public void Dispose()
	{
		Value?.Dispose();
	}
}
}