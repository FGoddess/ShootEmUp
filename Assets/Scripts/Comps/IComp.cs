namespace Comps
{
public interface IComp<T>
{
	public T Value { get; }
	
	public void Set(T value);
}
}