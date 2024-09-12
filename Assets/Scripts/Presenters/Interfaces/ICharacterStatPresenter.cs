namespace Presenters.Interfaces
{
public interface ICharacterStatPresenter : IPresenter
{
	public string Name  { get; }
	public int    Value { get; }
}
}