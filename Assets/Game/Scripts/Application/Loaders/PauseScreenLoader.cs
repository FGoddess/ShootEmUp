using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace SampleGame
{
public class PauseScreenLoader : MonoBehaviour
{
	[SerializeField] private AssetReference _pauseScreenReference;
	[SerializeField] private AssetReference _pauseButtonReference;
	[SerializeField] private Transform      _screenParent;

	private readonly List<AsyncOperationHandle> _loadedAssets     = new();
	private readonly List<GameObject>           _createdInstances = new();

	private DiContainer _container;

	[Inject]
	private void Construct(DiContainer container)
	{
		_container = container;
	}

	private async UniTaskVoid Awake()
	{
		await LoadPauseScreen();
		await LoadPauseButton();
	}

	private async UniTask LoadPauseScreen()
	{
		var loadOp = Addressables.LoadAssetAsync<GameObject>(_pauseScreenReference);
		_loadedAssets.Add(loadOp);

		await loadOp.Task;

		if (loadOp.Status == AsyncOperationStatus.Succeeded)
		{
			var screenInstance = _container.InstantiatePrefabForComponent<PauseScreen>(
				loadOp.Result,
				_screenParent
			);

			_createdInstances.Add(screenInstance.gameObject);

			if (!_container.HasBinding<PauseScreen>())
				_container.Bind<PauseScreen>().FromInstance(screenInstance).AsSingle();

			Debug.Log("Pause screen Instantiated");
		}
		else
		{
			Debug.LogError("Failed to load Pause screen prefab");
		}
	}

	private async UniTask LoadPauseButton()
	{
		var loadOp = Addressables.LoadAssetAsync<GameObject>(_pauseButtonReference);
		_loadedAssets.Add(loadOp);

		await loadOp.Task;

		if (loadOp.Status == AsyncOperationStatus.Succeeded)
		{
			var buttonInstance = _container.InstantiatePrefabForComponent<PauseButton>(
				loadOp.Result,
				_screenParent
			);

			_createdInstances.Add(buttonInstance.gameObject);
			buttonInstance.transform.SetSiblingIndex(0);

			Debug.Log("Pause button Instantiated");
		}
		else
		{
			Debug.LogError("Failed to load Pause button prefab");
		}
	}

	private void OnDestroy()
	{
		foreach (var instance in _createdInstances)
			Destroy(instance);

		_createdInstances.Clear();

		foreach (var handle in _loadedAssets)
			if (handle.IsValid())
				Addressables.Release(handle);

		_loadedAssets.Clear();
	}
}
}