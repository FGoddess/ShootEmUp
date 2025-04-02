using Atomic.Entities;

namespace Common
{
public class TakeDamageRequestBehaviour : IEntityInit
{
	public void Init(IEntity entity)
	{
		var request = entity.GetDamageRequest();
		request.Subscribe(damage => entity.GetHitPoints().Value -= damage);
	}
}
}