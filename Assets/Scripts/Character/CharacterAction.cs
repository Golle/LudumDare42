using UnityEngine;

namespace Assets.Scripts.Character
{
    internal abstract class CharacterAction : ScriptableObject
    {
        public virtual void OnEnter(ICharacterController characterController)
        {
        }

        public virtual void OnLeave(ICharacterController characterController)
        {
        }

        public virtual void OnUpdate(ICharacterController characterController)
        {
        }
    }
}