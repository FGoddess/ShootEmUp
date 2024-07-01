using System;
using Common;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
public class UiPauseScreen : MonoBehaviour, IGameStartListener, IGameFinishListener
{
	[SerializeField]
	private Button _pauseButton;
	[SerializeField]
	private Button _resumeButton;
	
	
	public event Action PauseButtonPressed;
	public event Action ResumeButtonPressed;

	public void OnStart()
	{
		_pauseButton.onClick.AddListener(() =>
			{
				PauseButtonPressed?.Invoke();
				gameObject.SetActive(true);
			}
		);
		_resumeButton.onClick.AddListener(() =>
			{
				ResumeButtonPressed?.Invoke();
				gameObject.SetActive(false);
			}
		);
	}

	public void OnFinish()
	{
		_pauseButton.onClick.RemoveAllListeners();
		_resumeButton.onClick.RemoveAllListeners();
	}
}
}