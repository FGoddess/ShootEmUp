using System;
using Configs;
using UI;

namespace Core
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
		Health = Math.Min(Health + value, Config.MaxHealth);
	}
}
}