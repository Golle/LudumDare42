namespace Assets.Scripts.Ioc
{
    internal interface IServiceCollection
    {
        T GetInstance<T>();

    }
}