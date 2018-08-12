using Assets.Scripts.Items;

namespace Assets.Scripts.EventSystem.Events
{
    internal class BurnableItemRecycledEvent : IEvent
    {
        public IItem Item { get; }
        public BurnableItemRecycledEvent(IItem item)
        {
            Item = item;
        }
    }
}