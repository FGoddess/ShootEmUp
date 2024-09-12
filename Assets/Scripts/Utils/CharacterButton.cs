using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
public class CharacterButton : MonoBehaviour
{
	[SerializeField]
	private Button _button;
	[SerializeField]
	private TMP_Text _text;

	public Button Button => _button;

	public void SetText(string text)
	{
		_text.text = text;
	}
}
}