using TMPro;
using UnityEngine;
using DI.Signals;

namespace TutorialHW
{
public class TutorialHintsService : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _text;

	public void SetHintText(string text)
	{
		_text.text = text;
	}
	
	public void OnTutorialCompleted(TutorialCompletedSignal signal)
	{
		gameObject.SetActive(false);
	}
}
}