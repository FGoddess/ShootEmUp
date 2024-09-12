using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UniRx;

namespace Models
{
[Serializable]
public sealed class CharacterInfo
{
	[ShowInInspector]
	private readonly ReactiveCollection<CharacterStat> _stats;

	public IReadOnlyReactiveCollection<CharacterStat> Stats => _stats;

	public CharacterInfo(HashSet<CharacterStat> stats)
	{
		_stats = new ReactiveCollection<CharacterStat>(stats);
	}

	[Button]
	public void AddStat(CharacterStat stat)
	{
		if (!_stats.Contains(stat))
			_stats.Add(stat);
	}

	[Button]
	public void RemoveStat(CharacterStat stat)
	{
		_stats.Remove(stat);
	}

	public CharacterStat GetStat(string name)
	{
		foreach (var stat in _stats)
			if (stat.Name == name)
				return stat;

		throw new Exception($"Stat {name} is not found!");
	}

	public CharacterStat[] GetStats()
	{
		return _stats.ToArray();
	}
}
}