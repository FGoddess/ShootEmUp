using Core.Events;
using Core.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.Handlers
{
public class SelectHeroHandler
{
	private SelectHeroTask _selectHeroTask;

	[Inject]
	public void Construct(SelectHeroTask selectHeroTask)
	{
		_selectHeroTask = selectHeroTask;
	}

	public async void WaitHeroSelectionAsync(SelectHeroSignal signal)
	{
		Debug.Log("Do logic signal");
		await UniTask.WaitUntil(() => Input.GetMouseButtonDown(0));
		_selectHeroTask.Complete();
		Debug.Log("prikol");
	}
}
}