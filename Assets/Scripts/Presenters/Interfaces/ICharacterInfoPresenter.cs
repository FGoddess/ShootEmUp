using System.Collections.Generic;
using Models;

namespace Presenters.Interfaces
{
public interface ICharacterInfoPresenter : IPresenter
{
	public IReadOnlyList<ICharacterStatPresenter> ProductPresenters { get; }
}
}