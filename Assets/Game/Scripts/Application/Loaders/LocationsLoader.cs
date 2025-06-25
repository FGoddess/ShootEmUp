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

	private int _currentLocationId = -1;

	private AsyncOperationHandle<GameObject> _baseLocationHandle;
	private AsyncOperationHandle<GameObject> _currentLoadedLocation;


	[Inject]
	public void Construct(LocationsConfig config)
	{
		_config = config;
	}

	private async UniTaskVoid Start()
	{
		_baseLocationHandle = await LoadLocation(_config.BaseLocation);
	}

	private void OnDestroy()
	{
		TryUnloadCurrentLocation();
		UnloadLocation(_baseLocationHandle);
	}

	public void OnZoneLoadSignal(ZoneLoadSignal signal)
	{
		if (_currentLocationId == signal.ZoneId)
			return;

		LoadLocation(signal.ZoneId).Forget();
	}

	public async UniTask LoadLocation(int locationId)
	{
		if (locationId < 0 || locationId >= _config.LocationsReferencesById.Length)
		{
			Debug.LogError($"Invalid location id: {locationId}");
			return;
		}

		if (_currentLocationId >= 0)
			TryUnloadCurrentLocation();

		var locationReference = _config.LocationsReferencesById[locationId];
		_currentLoadedLocation = await LoadLocation(locationReference);

		if (_currentLoadedLocation.Status == AsyncOperationStatus.Succeeded)
			_currentLocationId = locationId;
	}

	private async UniTask<AsyncOperationHandle<GameObject>> LoadLocation(AssetReference locationReference)
	{
		var handle = Addressables.InstantiateAsync(locationReference, _locationsParent);
		await handle.Task;

		if (handle.Status == AsyncOperationStatus.Succeeded)
			Debug.Log($"Location loaded: {handle.Result.name}");
		else
			Debug.LogError($"Failed to load location: {locationReference}");

		return handle;
	}

	public void TryUnloadCurrentLocation()
	{
		if (_currentLocationId < 0)
			return;

		UnloadLocation(_currentLoadedLocation);
		_currentLocationId = -1;
	}

	private void UnloadLocation(AsyncOperationHandle<GameObject> handle)
	{
		if (handle.IsValid())
			Addressables.ReleaseInstance(handle);
	}
}
}