using Chests.Configs;
using Chests.Presenters;
using Chests.View;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Chests
{
public class ChestsContext : MonoBehaviour
{
	private ChestsService _chestsService;

	[Inject]
	private void Construct(ChestsService chestsService, ChestListView chestListView)
	{
		_chestsService = chestsService;

		var presenter = new ChestListViewPresenter(_chestsService);
		chestListView.Initialize(presenter);
	}

	[Button]
	private void AddChest(ChestConfig config)
	{
		_chestsService.Add(config);
	}
}
}