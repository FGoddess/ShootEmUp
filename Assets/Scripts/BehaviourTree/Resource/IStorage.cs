namespace BehaviourTree.Resource
{
public interface IStorage<T>
{
	public T Value { get; }

	public void Set(T    value);
	public void Change(T value);
}
}