using UnityEngine;
using Zenject;

namespace SampleGame
{
[RequireComponent(typeof(BoxCollider))]
public class ZoneLoadTrigger : MonoBehaviour
{
	[SerializeField] private int _zoneId;

	private SignalBus _signalBus;

	[Inject]
	public void Construct(SignalBus signalBus)
	{
		_signalBus = signalBus;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<Character>(out _))
			_signalBus.Fire(new ZoneLoadSignal(_zoneId));
	}
}
}