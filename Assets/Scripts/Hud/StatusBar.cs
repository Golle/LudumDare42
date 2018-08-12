using Assets.Scripts.EventSystem.Events;
using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Hud
{
    internal class StatusBar : BehaviourBase
    {
        [SerializeField]
        private StatusText _plastic;
        [SerializeField]
        private StatusText _others;
        [SerializeField]
        private StatusText _trash;


        void Awake()
        {
            _trash.SetFormat("{0} (44)");
        }
        void OnEnable()
        {
            Subscribe<ItemBurnedEvent>(OnItemBurned);
            Subscribe<ItemRecycledEvent>(OnItemRecycled);

            Subscribe<NewRoundStartedEvent>(OnNewRound);
            Subscribe<CarryableItemPickedUpEvent>(OnItemPickedUp);
        }

        void OnDisable()
        {
            Unsubscribe<ItemBurnedEvent>(OnItemBurned);
            Unsubscribe<ItemRecycledEvent>(OnItemRecycled);
            Unsubscribe<NewRoundStartedEvent>(OnNewRound);
            Unsubscribe<CarryableItemPickedUpEvent>(OnItemPickedUp);
        }

        private void OnNewRound(NewRoundStartedEvent @event)
        {
            var count = @event.Items.Length;
            _trash.Increase(count);
        }

        private void OnItemPickedUp(CarryableItemPickedUpEvent obj)
        {
            _trash.Increase(-1);
        }

        private void OnItemRecycled(ItemRecycledEvent obj)
        {
            _plastic.Increase();
        }

        private void OnItemBurned(ItemBurnedEvent obj)
        {
            _others.Increase();
        }
    }
}
