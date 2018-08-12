using UnityEngine;

namespace Assets.Scripts.Character.Walking
{
    internal interface IMovement
    {
        void Move(Vector2 distance);
    }
}