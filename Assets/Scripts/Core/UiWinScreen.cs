using System;
using TMPro;
using UnityEngine;

namespace Core
{
public class UiWinScreen : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _text;

	private void Awake()
	{
		gameObject.SetActive(false);
	}

	public void Show()
	{
		gameObject.SetActive(true);
	}

	public void SetText(string text)
	{
		_text.text = text;
	}
}
}