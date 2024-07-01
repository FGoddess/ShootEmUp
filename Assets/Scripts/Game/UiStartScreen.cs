using System;
using Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
public class UiStartScreen : MonoBehaviour, IGameStartListener, IGameFinishListener
{
	[SerializeField]
	private TextMeshProUGUI _countdownText;
	[SerializeField]
	private Button _startButton;
	
	public event Action StartButtonPressed;


	public void OnStart()
	{
		_startButton.onClick.AddListener(() =>
		{
			StartButtonPressed?.Invoke();
			_startButton.gameObject.SetActive(false);
		});
	}

	public void OnFinish()
	{
		_startButton.onClick.RemoveAllListeners();
	}
	
	public void SetCountdownText(float secsLeft)
	{
		_countdownText.text = $"{secsLeft}";
	}

	public void Deactivate()
	{
		gameObject.SetActive(false);
	}
}
}