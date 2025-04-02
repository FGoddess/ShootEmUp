using Atomic.Entities;

namespace Player
{
public class DamageSFXRequestBehaviour : IEntityInit
{
	public void Init(IEntity entity)
	{
		var request = entity.GetDamageRequest();
		var sound   = entity.GetDamageSFX();

		request.Subscribe(_ => sound.Play());
	}
}
}