using Assets.Scripts.Items;

namespace Assets.Scripts.EventSystem.Events
{
    internal class RecycableItemBurnedEvent : IEvent
    {
        public IItem Item { get; }

        public RecycableItemBurnedEvent(IItem item)
        {
            Item = item;
        }
    }
}