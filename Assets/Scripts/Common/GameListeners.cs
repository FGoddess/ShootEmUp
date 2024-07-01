namespace Common
{
public interface IGameListener { }

public interface IGamePauseListener : IGameListener
{
	void OnPause();
}

public interface IGameResumeListener : IGameListener
{
	void OnResume();
}

public interface IGameStartListener : IGameListener
{
	void OnStart();
}

public interface IGameFinishListener : IGameListener
{
	void OnFinish();
}

public interface IGameUpdateListener : IGameListener
{
	void OnUpdate();
}

public interface IGameFixedUpdateListener : IGameListener
{
	void OnFixedUpdate();
}
}