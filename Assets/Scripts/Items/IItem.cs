using UnityEngine;

namespace Assets.Scripts.Items
{
    internal interface IItem
    {
        string Name { get; }
        Sprite Sprite { get; }
    }
}