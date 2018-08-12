using Assets.Scripts.EventSystem.Events;
using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Sound
{
    internal class SoundManager : BehaviourBase
    {
        [SerializeField]
        private AudioClip _pickupSound;
        [SerializeField]
        private AudioClip _wrongItem;
        [SerializeField]
        private AudioClip _itemBurned;
        [SerializeField]
        private AudioClip _newRound;
        [SerializeField]
        private AudioClip _hitGround;
        [SerializeField]
        private AudioClip _win;
        [SerializeField]
        private AudioClip _lose;


        private AudioSource _soundPlayer;

        void Awake()
        {
            _soundPlayer = GetComponent<AudioSource>();
        }

        void OnEnable()
        {
            Subscribe<CarryableItemPickedUpEvent>(OnPickup);
            Subscribe<CarryableItemDroppedEvent>(OnDrop);
            Subscribe<RecycableItemBurnedEvent>(OnWrongItemBurned);
            Subscribe<BurnableItemRecycledEvent>(OnWrongItemRecycled);
            Subscribe<ItemBurnedEvent>(OnItemBurned);
            Subscribe<NewRoundStartedEvent>(OnNewRound);
            Subscribe<CarryableItemHitGroundEvent>(OnHitGround);
            Subscribe<OutOfSpaceEvent>(OnOutOfSpace);
            Subscribe<GameWonEvent>(OnGameWon);
        }

        void OnDisable()
        {
            Unsubscribe<CarryableItemPickedUpEvent>(OnPickup);
            Unsubscribe<CarryableItemDroppedEvent>(OnDrop);
            Unsubscribe<RecycableItemBurnedEvent>(OnWrongItemBurned);
            Unsubscribe<BurnableItemRecycledEvent>(OnWrongItemRecycled);
            Unsubscribe<ItemBurnedEvent>(OnItemBurned);
            Unsubscribe<NewRoundStartedEvent>(OnNewRound);
            Unsubscribe<CarryableItemHitGroundEvent>(OnHitGround);
            Unsubscribe<OutOfSpaceEvent>(OnOutOfSpace);
            Unsubscribe<GameWonEvent>(OnGameWon);
        }

        private void OnGameWon(GameWonEvent obj)
        {
            _soundPlayer.PlayOneShot(_win);
        }

        private void OnOutOfSpace(OutOfSpaceEvent obj)
        {
            _soundPlayer.PlayOneShot(_lose);
        }

        private void OnHitGround(CarryableItemHitGroundEvent obj)
        {
            _soundPlayer.PlayOneShot(_hitGround);
        }

        private void OnNewRound(NewRoundStartedEvent obj)
        {
            _soundPlayer.PlayOneShot(_newRound);
        }

        private void OnItemBurned(ItemBurnedEvent obj)
        {
            _soundPlayer.PlayOneShot(_itemBurned);
        }

        private void OnWrongItemRecycled(BurnableItemRecycledEvent obj)
        {
            _soundPlayer.PlayOneShot(_wrongItem);
        }

        private void OnWrongItemBurned(RecycableItemBurnedEvent obj)
        {
            _soundPlayer.PlayOneShot(_wrongItem);
        }

        private void OnDrop(CarryableItemDroppedEvent obj)
        {
            _soundPlayer.PlayOneShot(_pickupSound);
        }

        private void OnPickup(CarryableItemPickedUpEvent obj)
        {
            _soundPlayer.PlayOneShot(_pickupSound);
        }
    }
}
