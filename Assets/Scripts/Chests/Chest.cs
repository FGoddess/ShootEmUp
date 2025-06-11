using System;
using Chests.Configs;

namespace Chests
{
public class Chest
{
	public ChestConfig Config     { get; }
	public DateTime    CreateTime { get; private set; }

	public Chest(ChestConfig config, DateTime createTime)
	{
		Config     = config;
		CreateTime = createTime;
	}
}
}