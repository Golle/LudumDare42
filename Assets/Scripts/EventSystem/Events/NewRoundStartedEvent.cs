using Assets.Scripts.Items;

namespace Assets.Scripts.EventSystem.Events
{
    internal class NewRoundStartedEvent : IEvent
    {
        public IItem[] Items { get; }
        public NewRoundStartedEvent(IItem[] items)
        {
            Items = items;
        }
    }
}