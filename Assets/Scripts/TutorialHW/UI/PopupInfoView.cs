using System;
using DI.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TutorialHW.UI
{
public class PopupInfoView : MonoBehaviour
{
	[SerializeField]
	private Button _closeButton;

	public Button CloseButton => _closeButton;

	private SignalBus _signalBus;

	[Inject]
	public void Construct(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	private void OnEnable()
	{
		_closeButton.onClick.AddListener(() => Activate(false));
	}

	private void OnDisable()
	{
		_closeButton.onClick.RemoveAllListeners();
	}

	public void Activate(bool isActive)
	{
		gameObject.SetActive(isActive);
	}
}
}