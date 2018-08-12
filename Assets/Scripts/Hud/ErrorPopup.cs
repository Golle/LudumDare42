using Assets.Scripts.EventSystem.Events;
using UnityEngine;

namespace Assets.Scripts.Hud
{
    internal class ErrorPopup : BehaviourBase
    {
        [SerializeField]
        private MovingText _textPrefab;
        [SerializeField]
        private float _movingTextTime = 2f;
        void OnEnable()
        {
            Subscribe<RecycableItemBurnedEvent>(OnWrongItemBurned);
            Subscribe<BurnableItemRecycledEvent>(OnWrongItemRecycled);
            Subscribe<OutOfSpaceEvent>(OnOutOfSpace);
            Subscribe<GameWonEvent>(OnGameWon);
        }

        void OnDisable()
        {
            Unsubscribe<RecycableItemBurnedEvent>(OnWrongItemBurned);
            Unsubscribe<BurnableItemRecycledEvent>(OnWrongItemRecycled);
            Unsubscribe<OutOfSpaceEvent>(OnOutOfSpace);
            Unsubscribe<GameWonEvent>(OnGameWon);
        }

        private void OnGameWon(GameWonEvent obj)
        {
            var text = Instantiate(_textPrefab, transform);
            text.Initialize($"Good Job! You didn't run out of space. Game will end in 10 seconds.", _movingTextTime);
        }

        private void OnOutOfSpace(OutOfSpaceEvent obj)
        {
            var text = Instantiate(_textPrefab, transform);
            text.Initialize($"You ran out of space..... Game will end in 5 seconds.", _movingTextTime);
        }

        private void OnWrongItemRecycled(BurnableItemRecycledEvent obj)
        {
            var text = Instantiate(_textPrefab, transform);
            text.Initialize($"You recycled a {obj.Item.Name}. You're not as smart as you think..", _movingTextTime);
        }

        private void OnWrongItemBurned(RecycableItemBurnedEvent obj)
        {
            var text = Instantiate(_textPrefab, transform);
            text.Initialize($"You burned a {obj.Item.Name}. It's supposed to be recycled!", _movingTextTime);
        }
    }
}
