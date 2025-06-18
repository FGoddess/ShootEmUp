using DI.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace TutorialHW.Controllers
{
public class OpenConveyorPopupController : TutorialStepController
{
	[SerializeField]
	private Vector3 _cursorOffset = new(100f, -50f);
	[SerializeField]
	private Button _conveyorUpgradesButton;

	protected override TutorialStep Step => TutorialStep.OpenConveyorPopup;

	public override void OnStepStarted()
	{
		TutorialHintsService.SetHintText("Пора прокачаться, откройте апгрейды!");
		
		_conveyorUpgradesButton.interactable = true;
		_conveyorUpgradesButton.onClick.AddListener(CompleteStep);

		TutorialCursor.SetActive(true);
		TutorialCursor.SetPosition(_conveyorUpgradesButton.transform.position + _cursorOffset);
	}

	protected override void CompleteStep()
	{
		_conveyorUpgradesButton.interactable = false;
		_conveyorUpgradesButton.onClick.RemoveAllListeners();
		TutorialCursor.SetActive(false);

		base.CompleteStep();
	}
}
}