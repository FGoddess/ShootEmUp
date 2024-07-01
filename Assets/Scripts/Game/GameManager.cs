using System;
using System.Collections.Generic;
using Common;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Game
{
public sealed class GameManager : SerializedMonoBehaviour
{
	[OdinSerialize] [ShowInInspector]
	[ListDrawerSettings(ShowIndexLabels = true)]
	private List<IGameListener> _gameListeners = new();

	private readonly List<IGameStartListener>       _startListeners       = new();
	private readonly List<IGamePauseListener>       _pauseListeners       = new();
	private readonly List<IGameResumeListener>      _resumeListeners      = new();
	private readonly List<IGameUpdateListener>      _updateListeners      = new();
	private readonly List<IGameFixedUpdateListener> _fixedUpdateListeners = new();
	private readonly List<IGameFinishListener>      _finishListeners      = new();
	

	private void Awake()
	{
		foreach (var listener in _gameListeners)
		{
			if (listener is IGameStartListener startListener)
				_startListeners.Add(startListener);
			if (listener is IGamePauseListener pauseListener)
				_pauseListeners.Add(pauseListener);
			if (listener is IGameResumeListener resumeListener)
				_resumeListeners.Add(resumeListener);
			if (listener is IGameUpdateListener updateListener)
				_updateListeners.Add(updateListener);
			if (listener is IGameFixedUpdateListener fixedUpdateListener)
				_fixedUpdateListeners.Add(fixedUpdateListener);
			if (listener is IGameFinishListener finishListener)
				_finishListeners.Add(finishListener);
		}
	}

	private void Start()
	{
		enabled = false;
		
		foreach (var listener in _startListeners)
			listener.OnStart();
	}

	public void PauseGame()
	{
		enabled = false;
		
		foreach (var listener in _pauseListeners)
			listener.OnPause();
	}

	public void ResumeGame()
	{
		enabled = true;
		
		foreach (var listener in _resumeListeners)
			listener.OnResume();
	}

	public void Update()
	{
		foreach (var listener in _updateListeners)
			listener.OnUpdate();
	}

	public void FixedUpdate()
	{
		foreach (var listener in _fixedUpdateListeners)
			listener.OnFixedUpdate();
	}

	public void FinishGame()
	{
		foreach (var listener in _finishListeners)
			listener.OnFinish();

		PauseGame();
		Debug.Log("Game over!");
	}
}
}