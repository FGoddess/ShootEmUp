using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace SampleGame
{
public class MenuScreenLoader : MonoBehaviour
{
	[SerializeField] private AssetReference _menuScreenReference;
	[SerializeField] private Transform      _screenParent;

	private AsyncOperationHandle<GameObject> _loadHandle;
	private GameObject                       _menuScreenInstance;

	private DiContainer _container;

	[Inject]
	private void Construct(DiContainer container)
	{
		_container = container;
	}

	private async void Awake()
	{
		_loadHandle = Addressables.LoadAssetAsync<GameObject>(_menuScreenReference);
		await _loadHandle.Task;

		if (_loadHandle.Status == AsyncOperationStatus.Succeeded)
		{
			_menuScreenInstance = _container.InstantiatePrefabForComponent<MenuScreen>(_loadHandle.Result, _screenParent).gameObject;

			Debug.Log("Menu screen Instantiated");
		}
		else
		{
			Debug.LogError("Failed to load Menu prefab");
		}
	}

	private void OnDestroy()
	{
		if (_menuScreenInstance != null)
			Destroy(_menuScreenInstance);

		if (_loadHandle.IsValid())
			Addressables.Release(_loadHandle);
	}
}
}