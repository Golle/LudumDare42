using Assets.Scripts.Character;
using Assets.Scripts.EventSystem.Events;
using UnityEngine;

namespace Assets.Scripts.Level
{
    internal class FailCondition : BehaviourBase
    {
        [SerializeField]
        private float _failTimer = 5f;

        private bool _lost;
        private IGameTime _gameTime;
        private float _timer;
        void Awake()
        {
            _gameTime = GetInstance<IGameTime>();
            _timer = _failTimer;
        }
        void OnEnable()
        {
            Subscribe<OutOfSpaceEvent>(OnOutOfSpace);
        }

        void OnDisable()
        {
            Subscribe<OutOfSpaceEvent>(OnOutOfSpace);
        }

        private void OnOutOfSpace(OutOfSpaceEvent obj)
        {
            _lost = true;
        }

        void Update()
        {
            if (_lost)
            {
                _timer -= _gameTime.DeltaTime;
                if (_timer <= 0)
                {
                    RaiseEvent(new GameFinishedEvent());
                    Destroy(this);
                }
            }
        }
    }
}
