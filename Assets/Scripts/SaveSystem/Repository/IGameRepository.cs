namespace SaveSystem.Repository
{
public interface IGameRepository
{
	void SetData<T>(T data);
	bool TryGetData<T>(out T data);

	void SaveState();
	void LoadState();
}
}