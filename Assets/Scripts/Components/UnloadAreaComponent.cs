namespace Components
{
public class UnloadAreaComponent : IComponent<int>
{
	public int Value { get; private set; }

	public void Set(int value)
	{
		Value = value;
	}
}
}