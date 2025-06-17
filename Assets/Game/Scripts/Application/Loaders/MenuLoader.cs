using Cysharp.Threading.Tasks;

namespace SampleGame
{
public sealed class MenuLoader
{
	private readonly SceneLoader  _sceneLoader;
	private readonly ScenesConfig _scenesConfig;

	public MenuLoader(SceneLoader sceneLoader, ScenesConfig scenesConfig)
	{
		_sceneLoader  = sceneLoader;
		_scenesConfig = scenesConfig;
	}

	public void LoadMenu()
	{
		_sceneLoader.LoadScene(_scenesConfig.MenuScene).Forget();
	}
}
}