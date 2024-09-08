using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Game
{
public class GameStartup : MonoBehaviour
{
	[SerializeField]
	private float _startDelay = 3f;
	
	private float _countdown;

	private const float SEC_TICK = 1f;

	public event Action        CountdownEnded;
	public event Action<float> CountdownTimeChanged;
	
	
	public void Startup()
	{
		_countdown = _startDelay;
		StartCoroutine(CrGameStart());
	}

	private IEnumerator CrGameStart()
	{
		while (_countdown > 0f)
		{
			CountdownTimeChanged?.Invoke(_countdown);
			_countdown -= SEC_TICK;
			yield return new WaitForSeconds(SEC_TICK);
		}

		CountdownEnded?.Invoke();
	}
}
}