using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace SceneInstallers
{
public class SceneInstaller : SceneContextInstallerBase
{
	[SerializeField]
	private SceneEntity _player;

	public override void Install(IContext context)
	{
		context.AddPlayer(_player);
		context.AddIsPlaying(true);
	}
}
}