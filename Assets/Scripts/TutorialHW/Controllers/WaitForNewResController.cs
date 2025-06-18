using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace TutorialHW.Controllers
{
public class WaitForNewResController : TutorialStepController
{
	[SerializeField]
	private float _waitTime = 3f;
	[SerializeField]
	private TextMeshProUGUI _timerText;

	private float _timer;

	protected override TutorialStep Step => TutorialStep.WaitForNewRes;


	public override void OnStepStarted()
	{
		TutorialHintsService.SetHintText("Подождите, пока ресурсы переработаются!");
		ShowTimerAsync().Forget();
	}

	private async UniTaskVoid ShowTimerAsync()
	{
		_timer          = _waitTime;
		_timerText.text = $"{_timer} сек.";

		while (_timer > 0f)
		{
			await UniTask.Delay(1000);
			_timer          -= 1f;
			_timerText.text =  $"{_timer} сек.";
		}

		_timerText.text = "Таймер";
		CompleteStep();
	}
}
}