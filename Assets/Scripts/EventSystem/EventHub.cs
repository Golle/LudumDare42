using System;
using System.Collections.Generic;
using Assets.Scripts.EventSystem.Events;
using UnityEngine;

namespace Assets.Scripts.EventSystem
{
    internal class EventHub : IEventHub
    {
        private readonly IDictionary<Type, object> _listeners = new Dictionary<Type, object>();
        
        public void RaiseEvent<T>(T @event) where T : IEvent
        {
            object eventHandler;
            if (_listeners.TryGetValue(typeof(T), out eventHandler))
            {
                (eventHandler as InternalEventHandler<T>)?.RaiseEvent(@event);
            }
            Debug.Log($"{@event.GetType().Name} raised.");
        }

        public void Subscribe<T>(Action<T> callback) where T : IEvent
        {
            object eventHandler;
            var type = typeof(T);
            if (_listeners.TryGetValue(type, out eventHandler))
            {
                (eventHandler as InternalEventHandler<T>)?.Subscribe(callback);
            }
            else
            {
                var handler = new InternalEventHandler<T>();
                handler.Subscribe(callback);
                _listeners[type] = handler;
            }
        }

        public void Unsubscribe<T>(Action<T> callback) where T : IEvent
        {
            object eventHandler;
            if (_listeners.TryGetValue(typeof(T), out eventHandler))
            {
                (eventHandler as InternalEventHandler<T>)?.Unsubscribe(callback);
            }
        }
    }
}