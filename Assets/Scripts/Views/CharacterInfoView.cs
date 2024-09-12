using System;
using System.Collections.Generic;
using Presenters.Interfaces;
using UniRx;
using UnityEngine;

namespace Views
{
//Сделал object pool прямо в этом классе, не захотелось выносить его 
public class CharacterInfoView : MonoBehaviour
{
    [SerializeField]
    private CharacterStatView _prefab;
    [SerializeField]
    private Transform _container;

    private ICharacterInfoPresenter _characterInfoPresenter;

    private readonly List<CharacterStatView> _activeCharacterStatViews = new();
    private readonly Queue<CharacterStatView> _pooledCharacterStatViews = new();
    private readonly CompositeDisposable _disposables = new();
    

    public void Show(IPresenter presenter)
    {
        if (presenter is not ICharacterInfoPresenter characterInfoPresenter)
            throw new ArgumentException("CharacterPopup must implement ICharacterPresenter");

        _characterInfoPresenter = characterInfoPresenter;

        foreach (var iStat in _characterInfoPresenter.StatsPresenters)
            CreateStatView(iStat.Value);

        _characterInfoPresenter.StatsPresenters.ObserveAdd()
                               .Subscribe(addEvent => CreateStatView(addEvent.Value))
                               .AddTo(_disposables);

        _characterInfoPresenter.StatsPresenters.ObserveRemove()
                               .Subscribe(removeEvent => RemoveStatView(removeEvent.Value))
                               .AddTo(_disposables);
    }

    private void CreateStatView(IPresenter statPresenter)
    {
        CharacterStatView item;
        
        if (_pooledCharacterStatViews.Count > 0)
        {
            item = _pooledCharacterStatViews.Dequeue();
            item.gameObject.SetActive(true);
        }
        else
        {
            item = Instantiate(_prefab, _container);
        }
        
        _activeCharacterStatViews.Add(item);
        item.Show(statPresenter);
    }

    private void RemoveStatView(IPresenter statPresenter)
    {
        var view = _activeCharacterStatViews.Find(characterStatView => characterStatView.Presenter == statPresenter);
        view.Hide();
        _activeCharacterStatViews.Remove(view);
        ReturnToPool(view);
    }

    private void ReturnToPool(CharacterStatView view)
    {
        view.gameObject.SetActive(false);
        _pooledCharacterStatViews.Enqueue(view);
    }

    public void Hide()
    {
        _disposables.Clear();

        foreach (var view in _activeCharacterStatViews)
        {
            view.Hide();
            ReturnToPool(view);
        }

        _activeCharacterStatViews.Clear();
    }

    private void OnDestroy()
    {
        _disposables.Dispose();
    }
}
}