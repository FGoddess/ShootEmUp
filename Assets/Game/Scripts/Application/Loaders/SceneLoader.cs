using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace SampleGame
{
public class SceneLoader
{
	private AsyncOperationHandle<SceneInstance> _loadHandle;

	public async UniTask LoadScene(AssetReference sceneReference)
	{
		_loadHandle = Addressables.LoadSceneAsync(sceneReference);
		await _loadHandle.Task;

		if (_loadHandle.Status == AsyncOperationStatus.Succeeded)
			Debug.Log("Scene loaded");
		else
			Debug.LogError($"Failed to load scene");
	}

	public async UniTask UnloadScene()
	{
		var operation = Addressables.UnloadSceneAsync(_loadHandle);
		await operation.Task;

		if (operation.Status == AsyncOperationStatus.Succeeded)
			Debug.Log($"Scene unloaded");
		else
			Debug.LogError($"Failed to unload scene");
	}
}
}