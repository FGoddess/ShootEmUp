using System.Collections.Generic;
using Models;
using UniRx;

namespace Presenters.Interfaces
{
public interface ICharacterInfoPresenter : IPresenter
{
	public ReactiveDictionary<CharacterStat, ICharacterStatPresenter> StatsPresenters { get; }
}
}