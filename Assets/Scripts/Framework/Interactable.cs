using UnityEngine.Events;

namespace Assets.Scripts.Framework
{
    internal class Interactable : BehaviourBase
    {
        private UnityEvent _onButtonDown;

        void OnMouseDown()
        {
            _onButtonDown?.Invoke();
        }
    }
}