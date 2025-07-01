namespace DI.Contexts
{
public interface IServicesContext
{
	T GetService<T>();
}
}