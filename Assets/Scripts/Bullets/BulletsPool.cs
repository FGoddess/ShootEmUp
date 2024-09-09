using Common;
using UnityEngine;
using Zenject;

namespace Bullets
{
public class BulletsPool : ObjectPool<Bullet>
{
	public BulletsPool(IFactory<Transform, Bullet> factory, Transform container, int initialCount) :
		base(factory, container, initialCount) { }
}
}