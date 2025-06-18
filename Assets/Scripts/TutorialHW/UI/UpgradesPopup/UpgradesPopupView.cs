using UnityEngine;
using UnityEngine.UI;

namespace TutorialHW.UI.UpgradesPopup
{
public class UpgradesPopupView : MonoBehaviour
{
	[SerializeField]
	private Image _fadingImage;
	[SerializeField]
	private Button _closeButton;

	public Button CloseButton => _closeButton;

	private void OnEnable()
	{
		_closeButton.onClick.AddListener(() => gameObject.SetActive(false));
	}

	private void OnDisable()
	{
		_closeButton.onClick.RemoveAllListeners();
	}
}
}