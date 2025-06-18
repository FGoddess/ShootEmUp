using UnityEngine;
using UnityEngine.UI;

namespace TutorialHW.UI
{
public class PopupInfoView : MonoBehaviour
{
	[SerializeField]
	private Button _closeButton;

	public Button CloseButton => _closeButton;

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