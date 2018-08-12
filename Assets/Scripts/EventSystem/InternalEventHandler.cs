using System;
using Assets.Scripts.EventSystem.Events;

namespace Assets.Scripts.EventSystem
{
    internal class InternalEventHandler<T> where T : IEvent
    {
        public event Action<T> EventHandler;

        public void Subscribe(Action<T> callback)
        {
            EventHandler += callback;
        }

        public void Unsubscribe(Action<T> callback)
        {
            EventHandler -= callback;
        }

        public void RaiseEvent(T @event)
        {
            EventHandler?.Invoke(@event);
        }
    }
}