using TutorialHW.UI.UpgradesPopup;
using UnityEngine;
using UnityEngine.UI;

namespace TutorialHW.Controllers
{
public class UpgradeConveyorController : TutorialStepController
{
	[SerializeField]
	private UpgradesPopupView _upgradesPopupView;
	[SerializeField]
	private UpgradeView _targetUpgradeView;
	[SerializeField]
	private Image _upgradesFadingImage;
	[SerializeField]
	private Vector3 _cursorUpgradeOffset = new(10f, -10f);
	[SerializeField]
	private Vector3 _cursorCloseButtonOffset = new(0f, 0f);

	protected override TutorialStep Step => TutorialStep.UpgradeConveyor;

	public override void OnStepStarted()
	{
		TutorialHintsService.SetHintText("Выберите первый апгрейд!");

		TutorialCursor.SetActive(true);
		TutorialCursor.SetPosition(_targetUpgradeView.UpgradeButton.transform.position + _cursorUpgradeOffset);

		_upgradesFadingImage.gameObject.SetActive(true);
		_targetUpgradeView.UpgradeButton.onClick.AddListener(OnButtonClicked);
	}

	private void OnButtonClicked()
	{
		TutorialHintsService.SetHintText("Уровень повысился, можно закрыть окно!");
		TutorialCursor.SetPosition(_upgradesPopupView.CloseButton.transform.position + _cursorCloseButtonOffset);

		_targetUpgradeView.transform.SetSiblingIndex(0);
		_targetUpgradeView.UpgradeButton.onClick.RemoveAllListeners();
		_targetUpgradeView.UpgradeButton.interactable = false;
		_targetUpgradeView.SetLevel($"Level: 2/20");

		_upgradesPopupView.CloseButton.onClick.AddListener(CompleteStep);
	}

	protected override void CompleteStep()
	{
		_upgradesPopupView.CloseButton.onClick.RemoveListener(CompleteStep);

		TutorialCursor.SetActive(false);
		_upgradesFadingImage.gameObject.SetActive(false);

		base.CompleteStep();
	}
}
}