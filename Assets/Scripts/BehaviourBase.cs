using System;
using Assets.Scripts.EventSystem;
using Assets.Scripts.EventSystem.Events;
using Assets.Scripts.Ioc;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class BehaviourBase : MonoBehaviour
    {

        private static readonly object Lock = new object();
        private static IEventHub _eventHub;
        private static IServiceCollection _serviceCollection;

        protected void RaiseEvent<T>(T @event) where T : IEvent
        {
            EventHub.RaiseEvent(@event);
        }

        protected void Subscribe<T>(Action<T> callback) where T : IEvent
        {
            EventHub.Subscribe(callback);
        }

        protected void Unsubscribe<T>(Action<T> callback) where T : IEvent
        {
            EventHub.Unsubscribe(callback);
        }

        protected T GetInstance<T>()
        {
            return ServiceCollection.GetInstance<T>();
        }

        private IEventHub EventHub
        {
            get
            {
                EnsureInitialized();
                return _eventHub;
            }
        }

        private IServiceCollection ServiceCollection
        {
            get
            {
                EnsureInitialized();
                return _serviceCollection;
            }
        }

        private static void EnsureInitialized()
        {
            if (_eventHub == null)
            {
                lock (Lock)
                {
                    if (_eventHub == null)
                    {
                        _serviceCollection = new ServiceCollection();
                        _eventHub = _serviceCollection.GetInstance<IEventHub>();

                    }
                }
            }
        }
    }
}