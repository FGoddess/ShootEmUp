using Atomic.Contexts;
using Atomic.Entities;
using TMPro;
using UnityEngine;
using SceneContext = SceneInstallers.SceneContext;

namespace UI
{
public class UiStatsPanel : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _hitPointsText;
	[SerializeField]
	private TextMeshProUGUI _bulletsText;
	[SerializeField]
	private TextMeshProUGUI _killsText;

	private void Start()
	{
		var player = SceneContext.Instance.GetPlayer();

		var bullets    = player.Entity.GetBullets();
		int maxBullets = player.Entity.GetMaxBullets();
		_bulletsText.text = $"bullets: {bullets.Value}/{maxBullets}";
		bullets.Subscribe(count => { _bulletsText.text = $"bullets: {count}/{maxBullets}"; });

		var hitPoints = player.Entity.GetHitPoints();
		_hitPointsText.text = $"hit points: {hitPoints.Value}";
		hitPoints.Subscribe(count => { _hitPointsText.text = $"hit points: {count}"; });

		var kills = player.Entity.GetKills();
		_killsText.text = $"kills: {kills.Value}";
		kills.Subscribe(count => { _killsText.text = $"kills: {count}"; });
	}
}
}