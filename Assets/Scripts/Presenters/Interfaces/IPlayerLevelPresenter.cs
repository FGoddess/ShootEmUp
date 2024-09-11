namespace Presenters.Interfaces
{
public interface IPlayerLevelPresenter : IPresenter
{
	public int  Level              { get; }
	public int  CurrentExperience  { get; }
	public int  RequiredExperience { get; }
	public bool CanLevelUp         { get; }
}
}