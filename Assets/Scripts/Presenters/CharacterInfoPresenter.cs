using System.Collections.Generic;
using Models;
using Presenters.Interfaces;

namespace Presenters
{
public class CharacterInfoPresenter : ICharacterInfoPresenter
{
	public  IReadOnlyList<ICharacterStatPresenter> ProductPresenters => _presenters;
	private List<ICharacterStatPresenter>          _presenters = new();

	public CharacterInfoPresenter(CharacterStat[] stats)
	{
		
	}
}
}