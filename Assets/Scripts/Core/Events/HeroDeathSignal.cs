using Core.Hero;
using UnityEngine;

namespace Core.Events
{
public class HeroDeathSignal
{
	public HeroData Hero { get; private set; }

	public HeroDeathSignal(HeroData hero)
	{
		Hero = hero;
	}
}
} 