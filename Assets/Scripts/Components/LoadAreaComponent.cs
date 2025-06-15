namespace Components
{
public class LoadAreaComponent : IComponent<int>
{
	public int Value { get; private set; }

	public void Set(int value)
	{
		Value = value;
	}
}
}