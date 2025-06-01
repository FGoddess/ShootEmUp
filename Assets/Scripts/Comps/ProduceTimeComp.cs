namespace Comps
{
public class ProduceTimeComp : IComp<float>
{
	public float Value { get; private set; }

	public void Set(float value)
	{
		Value = value;
	}
}
}