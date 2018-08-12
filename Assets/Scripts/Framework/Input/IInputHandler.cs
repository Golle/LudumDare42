
using UnityEngine;

namespace Assets.Scripts.Framework.Input
{
    internal interface IInputHandler
    {
        bool Left { get; }
        bool Right { get; }
        bool Up { get; }
        bool Down { get; }
        bool Pickup { get; }
        bool Drop { get; }
        Vector3 MousePosition { get; } 

        bool Space { get; }
        bool Escape { get; }
    }
}