using UnityEngine;

namespace Core.Tasks
{
public class DealDamageTask : EventTask
{
	protected override void OnStart()
	{
		Debug.Log("deal damage start");
		Complete();
	}

	protected override void OnComplete()
	{
		Debug.Log("deal damage complete");
	}
}
}