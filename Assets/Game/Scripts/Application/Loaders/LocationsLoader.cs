using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace SampleGame
{
public class LocationsLoader : MonoBehaviour
{
	[SerializeField] private Transform _locationsParent;

	private LocationsConfig _config;

	private readonly List<AsyncOperationHandle<GameObject>> _loadedLocations = new();

	[Inject]
	public void Construct(LocationsConfig config)
	{
		_config = config;
	}

	private void Awake()
	{
		LoadAllLocations().Forget();
	}

	public async UniTask LoadAllLocations()
	{
		foreach (var locationReference in _config.LocationsReferences)
			await LoadLocation(locationReference);

		Debug.Log($"Loaded {_loadedLocations.Count} locations");
	}

	private async UniTask LoadLocation(AssetReference locationReference)
	{
		var instantiateHandle = Addressables.InstantiateAsync(locationReference, _locationsParent);
		_loadedLocations.Add(instantiateHandle);

		await instantiateHandle.Task;

		if (instantiateHandle.Status == AsyncOperationStatus.Succeeded)
			Debug.Log($"Location loaded: {instantiateHandle.Result.name}");
		else
			Debug.LogError($"Failed to load location: {locationReference}");
	}

	private void OnDestroy()
	{
		UnloadAllLocations();
	}

	public void UnloadAllLocations()
	{
		foreach (var handle in _loadedLocations)
			if (handle.IsValid())
				Addressables.ReleaseInstance(handle);

		_loadedLocations.Clear();
	}
}
}