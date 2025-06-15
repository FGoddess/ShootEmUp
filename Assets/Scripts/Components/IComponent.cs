namespace Components
{
public interface IComponent<T>
{
	public T Value { get; }
	
	public void Set(T value);
}
}