using System;
using Assets.Scripts.EventSystem.Events;

namespace Assets.Scripts.EventSystem
{
    internal interface IEventHub
    {
        void RaiseEvent<T>(T @event) where T : IEvent;
        void Subscribe<T>(Action<T> callback) where T : IEvent;
        void Unsubscribe<T>(Action<T> callback) where T : IEvent;
    }
}
