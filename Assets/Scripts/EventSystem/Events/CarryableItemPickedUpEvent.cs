using Assets.Scripts.Items;

namespace Assets.Scripts.EventSystem.Events
{
    internal class CarryableItemPickedUpEvent : IEvent
    {
        public CarryableItem Item { get; }
        public CarryableItemPickedUpEvent(CarryableItem item)
        {
            Item = item;
        }
    }
}