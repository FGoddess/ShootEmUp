namespace Comps
{
public class LoadAreaComp : IComp<int>
{
	public int Value { get; private set; }

	public void Set(int value)
	{
		Value = value;
	}
}
}