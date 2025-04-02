using Atomic.Entities;

namespace Player
{
public class DamageVFXRequestBehaviour : IEntityInit
{
	public void Init(IEntity entity)
	{
		var request = entity.GetDamageRequest();
		var vfx     = entity.GetDamageVFX();

		request.Subscribe(_ => vfx.Play());
	}
}
}