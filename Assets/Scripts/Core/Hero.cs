using Configs;
using UI;

namespace Core
{
public class Hero
{
	public HeroConfig Config;

	public HeroView View;
	
	public bool IsBlueTeam;

	public int Health;
	
	public HeroPipeline TurnPipeline;
}
}