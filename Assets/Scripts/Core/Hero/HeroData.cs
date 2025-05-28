using System;
using Configs;
using UI;

namespace Core.Hero
{
public class HeroData
{
	public HeroConfig Config;

	public HeroView View;

	public bool IsBlueTeam;
	public bool HasHolyShield;
	public int  FrozenTurns;
	
	public bool IsFrozen => FrozenTurns > 0;

	public int Health;

	public HeroPipeline ActionsPipeline;
	public HeroPipeline TurnEndPipeline;


	public void ChangeHealth(int value)
	{
		Health = Math.Clamp(Health + value, 0, Config.MaxHealth);
	}
}
}