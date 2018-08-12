using UnityEngine;

namespace Assets.Scripts.Character
{
    internal abstract class CharacterDecision : ScriptableObject
    {
        public virtual void Setup(ICharacterController characterController) { }
        public abstract bool ChangeState(ICharacterController characterController);
        public virtual void Teardown(ICharacterController characterController) { }
    }
}