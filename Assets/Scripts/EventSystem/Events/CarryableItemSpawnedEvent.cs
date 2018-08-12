using Assets.Scripts.Items;

namespace Assets.Scripts.EventSystem.Events
{
    internal class CarryableItemSpawnedEvent : IEvent
    {
        public CarryableItem Item { get; }

        public CarryableItemSpawnedEvent(CarryableItem item)
        {
            Item = item;
        }
    }
}