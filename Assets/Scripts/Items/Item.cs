using TMPro;
using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Items
{
    internal class Item : ScriptableObject, IItem
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private Sprite _sprite;
        public string Name => _name;
        public Sprite Sprite => _sprite;
    }
}
