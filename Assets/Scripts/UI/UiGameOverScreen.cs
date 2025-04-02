using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;
using SceneContext = SceneInstallers.SceneContext;

namespace UI
{
public class UiGameOverScreen : MonoBehaviour
{
	[SerializeField]
	private GameObject _gameOverScreen;

	private void Start()
	{
		var player = SceneContext.Instance.GetPlayer();
		player.GetHitPoints().Subscribe(hp =>
		{
			if (hp > 0)
				return;

			SceneContext.Instance.GetIsPlaying().Value = false;
			_gameOverScreen.SetActive(true);
			Time.timeScale = 0f;
		});
	}
}
}