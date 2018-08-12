using Assets.Scripts.Character;
using Assets.Scripts.EventSystem;
using Assets.Scripts.Framework.Input;
using Assets.Scripts.Scenes;

namespace Assets.Scripts.Ioc
{
    internal class ServiceRegistry
    {
        public static void RegisterServices(IContainer container)
        {
            container
                .Register<IEventHub, EventHub>()
                .Register<ISceneHandler, SceneHandler>()
                .Register<IInputHandler, InputHandler>()
                .Register<IGameTime, GameTime>()
                ;
        }
    }
}
