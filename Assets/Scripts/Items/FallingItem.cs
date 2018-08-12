using System;
using Assets.Scripts.EventSystem.Events;
using UnityEngine;

namespace Assets.Scripts.Items
{
    internal class FallingItem : BehaviourBase
    {
        [SerializeField]
        private float _speed;

        private Vector2 _destination;
        private Action _callback;

        public void Initialize(Vector2 destination, Action callback)
        {
            _destination = destination;
            _callback = callback;
        }

        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, _destination, _speed);
            if (Vector2.Distance(transform.position, _destination) <= 0.01f)
            {
                RaiseEvent(new CarryableItemHitGroundEvent());
                _callback();
                Destroy(this);
            }
        }

    }
}