using UnityEngine;

namespace Assets.Scripts.Character.Walking
{
    [CreateAssetMenu(menuName = "Custom/State Machine/Idle Decision")]
    internal class IdleDecision : CharacterDecision
    {
        public override bool ChangeState(ICharacterController characterController)
        {
            var input = characterController.Input;
            return !(input.Left || input.Right || input.Down || input.Up);
        }
    }
}