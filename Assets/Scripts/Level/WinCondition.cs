using Assets.Scripts.Character;
using Assets.Scripts.EventSystem.Events;
using UnityEngine;

namespace Assets.Scripts.Level
{
    internal class WinCondition : BehaviourBase
    {
        [SerializeField]
        private float _winTimer = 5f;

        private bool _won;
        private IGameTime _gameTime;
        private float _timer;

        private bool _outOfTrash;
        private bool _lastLevelCompleted;

        void Awake()
        {
            _gameTime = GetInstance<IGameTime>();
            _timer = _winTimer;
        }

        void OnEnable()
        {
            Subscribe<OutOfTrashEvent>(OnOutOfTrash);
            Subscribe<NewRoundStartedEvent>(OnNewRound);
            Subscribe<LastLevelCompletedEvent>(OnLastLevelCompleted);
        }

        void OnDisable()
        {
            Unsubscribe<OutOfTrashEvent>(OnOutOfTrash);
            Unsubscribe<NewRoundStartedEvent>(OnNewRound);
            Unsubscribe<LastLevelCompletedEvent>(OnLastLevelCompleted);
        }

        private void OnLastLevelCompleted(LastLevelCompletedEvent obj)
        {
            _lastLevelCompleted = true;
            DidWin();
        }

        private void DidWin()
        {
            if (!_won && _outOfTrash && _lastLevelCompleted)
            {
                _won = true;
                RaiseEvent(new GameWonEvent());
            }
        }

        private void OnNewRound(NewRoundStartedEvent obj)
        {
            _outOfTrash = false;
        }

        private void OnOutOfTrash(OutOfTrashEvent obj)
        {
            _outOfTrash = true;
            DidWin();
        }

        void Update()
        {
            if (_won)
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
