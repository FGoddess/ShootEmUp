using System;
using UnityEngine;

namespace TutorialHW.UI
{
public class TutorialCursor : MonoBehaviour
{
	[SerializeField] 
	private Vector2 _offset;

	public void SetPosition(Vector2 position)
	{
		transform.position = position;
	}

	public void SetActive(bool isActive)
	{
		gameObject.SetActive(isActive);
	}
}
}