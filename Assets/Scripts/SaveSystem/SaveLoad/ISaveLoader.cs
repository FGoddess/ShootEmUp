using Core;
using SaveSystem.Repository;

namespace SaveSystem.SaveLoad
{
public interface ISaveLoader
{
	void SaveGame(ServiceContext serviceContext, IGameRepository gameRepository);
	void LoadGame(ServiceContext serviceContext, IGameRepository gameRepository);
}

public abstract class SaveLoader<TService, TData> : ISaveLoader
{
	public void SaveGame(ServiceContext serviceContext, IGameRepository gameRepository)
	{
		var service = serviceContext.GetService<TService>();
		var data    = ConvertToData(service);
		gameRepository.SetData(data);
	}

	public void LoadGame(ServiceContext serviceContext, IGameRepository gameRepository)
	{
		var service = serviceContext.GetService<TService>();

		if (gameRepository.TryGetData(out TData data))
			SetupData(service, data);
		else
			SetupDefaultData(service);
	}

	protected abstract TData ConvertToData(TService service);
	protected abstract void SetupData(TService      service, TData data);

	protected virtual void SetupDefaultData(TService service) { }
}
}