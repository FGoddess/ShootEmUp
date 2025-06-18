using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TutorialHW.UI.UpgradesPopup
{
public sealed class UpgradeView : MonoBehaviour
{
	[SerializeField]
	private Button _upgradeButton;
	[SerializeField]
	private TextMeshProUGUI _levelText;

	public Button UpgradeButton => _upgradeButton;

	public void SetLevel(string level)
	{
		_levelText.text = level;
	}
}
}