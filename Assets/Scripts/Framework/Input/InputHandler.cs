using UnityEngine;

namespace Assets.Scripts.Framework.Input
{
    internal class InputHandler : IInputHandler
    {
        public bool Left => UnityEngine.Input.GetKey(KeyCode.A) || UnityEngine.Input.GetKey(KeyCode.LeftArrow);
        public bool Right => UnityEngine.Input.GetKey(KeyCode.D) || UnityEngine.Input.GetKey(KeyCode.RightArrow);
        public bool Up => UnityEngine.Input.GetKey(KeyCode.W) || UnityEngine.Input.GetKey(KeyCode.UpArrow);
        public bool Down => UnityEngine.Input.GetKey(KeyCode.S) || UnityEngine.Input.GetKey(KeyCode.DownArrow);
        public bool Pickup => UnityEngine.Input.GetMouseButtonDown(0);
        public bool Drop => UnityEngine.Input.GetMouseButtonDown(0);
        public Vector3 MousePosition => UnityEngine.Input.mousePosition;
        public bool Space => UnityEngine.Input.GetKey(KeyCode.Space);
        public bool Escape => UnityEngine.Input.GetKey(KeyCode.Escape);
    }
}