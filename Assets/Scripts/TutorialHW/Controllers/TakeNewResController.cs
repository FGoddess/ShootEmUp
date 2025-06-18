using DI.Signals;
using TutorialHW.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TutorialHW.Controllers
{
public class TakeNewResController : TutorialStepController
{
	[SerializeField]
	private Vector3 _cursorOffset = new(100f, -50f);
	[SerializeField]
	private Button _takeButton;

	protected override TutorialStep Step => TutorialStep.TakeNewRes;

	public override void OnStepStarted()
	{
		TutorialHintsService.SetHintText("Заберите новый ресурс!");
		
		_takeButton.interactable = true;
		_takeButton.onClick.AddListener(CompleteStep);

		TutorialCursor.SetActive(true);
		TutorialCursor.SetPosition(_takeButton.transform.position + _cursorOffset);
	}
	
	protected override void CompleteStep()
	{
		_takeButton.interactable = false;
		_takeButton.onClick.RemoveAllListeners();
		TutorialCursor.SetActive(false);

		base.CompleteStep();
	}
}
}