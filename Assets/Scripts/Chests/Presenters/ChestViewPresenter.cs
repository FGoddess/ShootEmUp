using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Chests.Presenters
{
public class ChestViewPresenter : IChestViewPresenter
{
	private readonly Chest               _chest;
	private readonly ChestsService       _chestsService;
	private readonly CompositeDisposable _disposable = new();

	public string                   Name        { get; }
	public Sprite                   Icon        { get; }
	public ReactiveProperty<string> TimeLeft    { get; }
	public ReactiveProperty<bool>   CanOpen     { get; }
	public ReactiveCommand          OpenCommand { get; }


	public ChestViewPresenter(Chest chest, ChestsService chestsService)
	{
		_chest         = chest;
		_chestsService = chestsService;

		Name        = chest.Config.Name;
		Icon        = chest.Config.Icon;
		TimeLeft    = new ReactiveProperty<string>();
		CanOpen     = new ReactiveProperty<bool>();
		OpenCommand = new ReactiveCommand();

		UpdateTimeLeft().Forget();
		OpenCommand.Subscribe(_ => chestsService.Open(chest)).AddTo(_disposable);
	}

	private async UniTask UpdateTimeLeft()
	{
		while (!CanOpen.Value)
		{
			TimeLeft.Value = _chestsService.TryGetChestTimeLeft(_chest, out var timeLeft) ? timeLeft.ToString(@"hh\:mm\:ss") : "Loading";

			if (timeLeft == TimeSpan.Zero)
				CanOpen.Value = true;

			await UniTask.Delay(1000);
		}
	}

	~ChestViewPresenter()
	{
		_disposable.Dispose();
	}
}
}