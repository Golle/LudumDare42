using Assets.Scripts.EventSystem.Events;
using Assets.Scripts.Items;
using UnityEngine;

namespace Assets.Scripts.Character
{
    internal class Carrying : BehaviourBase, ICarrying
    {
        private CarryableItem _currentItem;

        public void Pickup(CarryableItem carryableItem)
        {
            if (_currentItem == null && carryableItem.CanBePickedUp)
            {
                RaiseEvent(new CarryableItemPickedUpEvent(carryableItem));
                carryableItem.transform.SetParent(transform);
                carryableItem.transform.localPosition = Vector3.zero;
                _currentItem = carryableItem;
                _currentItem.OnPickup();
            }
        }

        public void DropAt(Dropzone dropzone)
        {
            if (_currentItem != null)
            {
                _currentItem.OnDrop();
                dropzone.DropItem(_currentItem);
                RaiseEvent(new CarryableItemDroppedEvent(_currentItem));
                _currentItem = null;
            }
        }
    }
}