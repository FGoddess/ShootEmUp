namespace Components
{
public class ProduceTimeComponent : IComponent<float>
{
	public float Value { get; private set; }

	public void Set(float value)
	{
		Value = value;
	}
}
}