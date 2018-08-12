using Assets.Scripts.Items;

namespace Assets.Scripts.EventSystem.Events
{
    internal class CarryableItemDroppedEvent : IEvent
    {
        public CarryableItem Item { get; }
        public CarryableItemDroppedEvent(CarryableItem item)
        {
            Item = item;
        }
    }
}