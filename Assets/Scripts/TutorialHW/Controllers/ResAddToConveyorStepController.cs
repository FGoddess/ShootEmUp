using UnityEngine;
using UnityEngine.UI;

namespace TutorialHW.Controllers
{
public class ResAddToConveyorStepController : TutorialStepController
{
	[SerializeField]
	private Vector3 _cursorOffset = new(100f, -50f);
	[SerializeField]
	private Button _resAddButton;

	protected override TutorialStep Step => TutorialStep.ResAddToConveyor;


	public override void OnStepStarted()
	{
		TutorialHintsService.SetHintText("Добавьте ресурсы в конвейер!");

		_resAddButton.interactable = true;
		_resAddButton.onClick.AddListener(CompleteStep);

		TutorialCursor.SetActive(true);
		TutorialCursor.SetPosition(_resAddButton.transform.position + _cursorOffset);
	}

	protected override void CompleteStep()
	{
		_resAddButton.interactable = false;
		_resAddButton.onClick.RemoveAllListeners();
		TutorialCursor.SetActive(false);

		base.CompleteStep();
	}
}
}