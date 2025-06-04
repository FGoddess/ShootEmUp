namespace Inventory.Interfaces
{
public interface ICloneable<out T> where T : ICloneable<T>
{
	public T Clone();
}
}