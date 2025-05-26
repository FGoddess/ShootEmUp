using UnityEngine;

namespace UI
{
public sealed class UIService : MonoBehaviour
{
	[SerializeField]
	private HeroListView _bluePlayer;
	[SerializeField]
	private HeroListView _redPlayer;

	public HeroListView BluePlayer => _bluePlayer;
	public HeroListView RedPlayer  => _redPlayer;

	
	public HeroListView GetCurrentPlayerView(bool isBlue)
	{
		return isBlue ? _bluePlayer : _redPlayer;
	}
}
}