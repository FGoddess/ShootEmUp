using System;
using UnityEngine;
using Zenject;

namespace SampleGame
{
public class Bootstrapper : MonoBehaviour
{
	private MenuLoader _menuLoader;

	[Inject]
	public void Construct(MenuLoader menuLoader)
	{
		_menuLoader = menuLoader;
	}

	private void Awake()
	{
		_menuLoader.LoadMenu();
	}
}
}