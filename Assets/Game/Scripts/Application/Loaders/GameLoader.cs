using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SampleGame
{
public sealed class GameLoader
{
	private readonly SceneLoader  _sceneLoader;
	private readonly ScenesConfig _scenesConfig;

	public GameLoader(SceneLoader sceneLoader, ScenesConfig scenesConfig)
	{
		_sceneLoader  = sceneLoader;
		_scenesConfig = scenesConfig;
	}

	public void LoadGame()
	{
		_sceneLoader.LoadScene(_scenesConfig.GameScene).Forget();
	}

	public void UnloadGame()
	{
		_sceneLoader.UnloadScene().Forget();
	}
}
}