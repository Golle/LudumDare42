using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Items
{
    [CreateAssetMenu(menuName = "Custom/Items/Item Collection")]
    internal class ItemCollection : ScriptableObject
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private Item[] _items;

        public Item[] Items => _items;

        public Item GetRandomItem()
        {
            return _items[Random.Range(0, _items.Length)];
        }
    }
}