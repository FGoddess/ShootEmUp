using System;
using Sirenix.OdinInspector;
using UniRx;

namespace Models
{
[Serializable]
public sealed class CharacterStat
{
	[ShowInInspector] [ReadOnly]
	public string Name { get; private set; }

	[ShowInInspector] [ReadOnly]
	public ReactiveProperty<int> Value { get; private set; }

	public CharacterStat(string name, int value)
	{
		Name  = name;
		Value = new ReactiveProperty<int>(value);
	}

	[Button]
	public void ChangeValue(int value)
	{
		Value.Value = value;
	}
}
}