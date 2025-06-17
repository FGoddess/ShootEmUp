using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SampleGame
{
public sealed class PauseScreen : MonoBehaviour
{
	[SerializeField]
	private Button resumeButton;

	[SerializeField]
	private Button exitButton;

	private MenuLoader menuLoader;

	[Inject]
	public void Construct(MenuLoader menuLoader, GameLoader gameLoader)
	{
		this.menuLoader = menuLoader;
		gameObject.SetActive(false);
	}

	private void OnEnable()
	{
		resumeButton.onClick.AddListener(Hide);
		exitButton.onClick.AddListener(menuLoader.LoadMenu);
	}

	private void OnDisable()
	{
		resumeButton.onClick.RemoveListener(Hide);
		exitButton.onClick.RemoveListener(menuLoader.LoadMenu);
	}

	public void Show()
	{
		Time.timeScale = 0; //KISS
		gameObject.SetActive(true);
	}

	public void Hide()
	{
		Time.timeScale = 1; //KISS
		gameObject.SetActive(false);
	}
}
}