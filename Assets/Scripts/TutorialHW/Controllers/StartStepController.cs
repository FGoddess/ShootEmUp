using DI.Signals;
using TutorialHW.UI;
using UnityEngine;
using Zenject;

namespace TutorialHW.Controllers
{
public class StartStepController : TutorialStepController
{
	[SerializeField]
	private PopupInfoView _popupInfoView;

	protected override TutorialStep Step => TutorialStep.Start;

	public override void OnStepStarted()
	{
		_popupInfoView.Activate(true);
		_popupInfoView.CloseButton.onClick.AddListener(OnCloseButtonClicked);
		
		TutorialHintsService.SetHintText("Добро пожаловать!");
	}

	private void OnCloseButtonClicked()
	{
		_popupInfoView.CloseButton.onClick.RemoveListener(OnCloseButtonClicked);
		
		CompleteStep();
	}
}
}