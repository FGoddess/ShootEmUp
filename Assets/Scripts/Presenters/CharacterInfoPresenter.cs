using System;
using System.Collections.Generic;
using Models;
using Presenters.Interfaces;
using UniRx;
using UnityEngine;
using CharacterInfo = Models.CharacterInfo;

namespace Presenters
{
public class CharacterInfoPresenter : ICharacterInfoPresenter, IDisposable
{
	public ReactiveDictionary<CharacterStat, ICharacterStatPresenter> StatsPresenters { get; private set; }

	private readonly CharacterPresenterFactory _characterPresenterFactory;

	private readonly CompositeDisposable _disposables = new();

	public CharacterInfoPresenter(CharacterInfo characterInfo, CharacterPresenterFactory characterPresenterFactory)
	{
		StatsPresenters            = new ReactiveDictionary<CharacterStat, ICharacterStatPresenter>();
		_characterPresenterFactory = characterPresenterFactory;
		
		for (int i = 0, count = characterInfo.Stats.Count; i < count; i++)
			AddStatPresenter(characterInfo.Stats[i]);

		characterInfo.Stats.ObserveAdd()
		             .Subscribe(addEvent => AddStatPresenter(addEvent.Value))
		             .AddTo(_disposables);


		characterInfo.Stats.ObserveRemove()
		             .Subscribe(removeEvent => RemoveStatPresenter(removeEvent.Value))
		             .AddTo(_disposables);
	}

	private void RemoveStatPresenter(CharacterStat stat)
	{
		StatsPresenters.Remove(stat);
	}

	private void AddStatPresenter(CharacterStat stat)
	{
		var presenter = _characterPresenterFactory.Create(stat);
		StatsPresenters.Add(stat, presenter as ICharacterStatPresenter);
	}

	public void Dispose()
	{
		_disposables?.Clear();
	}
}
}