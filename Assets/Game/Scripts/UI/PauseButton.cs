using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SampleGame
{
public sealed class PauseButton : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private PauseScreen _pauseScreen;

	private GameObject _pauseScreenInstance;

	[Inject]
	public void Construct(PauseScreen pauseScreen)
	{
		_pauseScreen = pauseScreen;
	}

	private void OnEnable()
	{
		button.onClick.AddListener(OnPauseButtonClicked);
	}

	private void OnDisable()
	{
		button.onClick.RemoveListener(OnPauseButtonClicked);
	}

	private void OnPauseButtonClicked()
	{
		_pauseScreen.Show();
	}
}
}