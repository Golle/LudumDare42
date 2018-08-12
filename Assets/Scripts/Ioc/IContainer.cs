namespace Assets.Scripts.Ioc
{
    internal interface IContainer
    {
        IContainer Register<TTypeToResolve, TConcrete>() where TConcrete : TTypeToResolve;
        TTypeToResolve GetInstance<TTypeToResolve>();
    }
}