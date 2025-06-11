using TMPro;
using UnityEngine;

namespace Session.Views
{
public class SessionDurationView : MonoBehaviour
{
	[SerializeField] private TMP_Text _durationText;

	public void SetDurationText(string duration)
	{
		_durationText.text = duration;
	}
}
}