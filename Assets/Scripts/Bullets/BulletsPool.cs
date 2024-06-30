using Common;
using UnityEngine;

namespace Bullets
{
public class BulletsPool : ObjectPool<Bullet>
{
	public BulletsPool(Bullet prefab, Transform container, int initialCount) : base(prefab, container, initialCount) { }
}
}