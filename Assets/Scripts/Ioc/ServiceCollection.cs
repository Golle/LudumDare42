namespace Assets.Scripts.Ioc
{
    internal class ServiceCollection : IServiceCollection
    {
        private readonly Container _container;
        public ServiceCollection()
        {
            _container = new Container();
            ServiceRegistry.RegisterServices(_container);
        }

        public T GetInstance<T>()
        {
            return _container.GetInstance<T>();
        }
    }
}