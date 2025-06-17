namespace BehaviourTree.Resource
{
public class ResourcesStorage : IStorage<int>
{
	public int Value { get; private set; }

	public void Set(int value)
	{
		Value = value;
	}

	public void Change(int value)
	{
		Value += value;
	}
}
}