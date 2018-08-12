using System.Linq;
using Assets.Scripts.Character;
using Assets.Scripts.EventSystem.Events;
using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Level
{
    internal class LevelManager : BehaviourBase
    {
        [SerializeField]
        private LevelDescriptor _levelDescriptor;

        [SerializeField]
        private float _startTime;

        private ILevel _level;
        private int _currentLevel;
        private IGameTime _gameTime;

        private int _roundsLeft;
        private float _timeLeft;
        private int _extraItems;

        void Awake()
        {
            _gameTime = GetInstance<IGameTime>();
        }

        void OnEnable()
        {
            Subscribe<RecycableItemBurnedEvent>(OnRecycableItemBurned);
            Subscribe<BurnableItemRecycledEvent>(OnBurnedItemRecycled);
        }

        void OnDisable()
        {
            Unsubscribe<RecycableItemBurnedEvent>(OnRecycableItemBurned);
            Unsubscribe<BurnableItemRecycledEvent>(OnBurnedItemRecycled);
        }

        private void OnBurnedItemRecycled(BurnableItemRecycledEvent obj)
        {
            _extraItems++;
        }

        private void OnRecycableItemBurned(RecycableItemBurnedEvent obj)
        {
            _extraItems++;
        }

        void Start()
        {
            _currentLevel = -1;
            _timeLeft = _startTime;
        }

        private void StartLevel()
        {
            _level = _levelDescriptor.Level[_currentLevel];
            _roundsLeft = _level.Rounds;
            NewRound();
        }

        private void NewRound()
        {
            _timeLeft = _level.TimeBetweenRounds;

            var items = _level.GetRandomItems(_extraItems).ToArray();
            _extraItems = 0;
            RaiseEvent(new NewRoundStartedEvent(items));
        }

        void Update()
        {
            _timeLeft -= _gameTime.DeltaTime;
            if (_timeLeft <= 0f)
            {
                _roundsLeft--;
                if (_roundsLeft <= 0f)
                {
                    NextLevel();
                    return;
                }
                NewRound();
            }
        }

        private void NextLevel()
        {
            _currentLevel++;
            if (_currentLevel >= _levelDescriptor.Level.Length)
            {
                enabled = false;
                RaiseEvent(new LastLevelCompletedEvent());
            }
            else
            {
                StartLevel();
            }
        }
    }
}
