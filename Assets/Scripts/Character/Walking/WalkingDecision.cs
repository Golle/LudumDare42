using UnityEngine;

namespace Assets.Scripts.Character.Walking
{
    [CreateAssetMenu(menuName = "Custom/State Machine/Walking Decision")]
    internal class WalkingDecision : CharacterDecision
    {
        public override bool ChangeState(ICharacterController characterController)
        {
            var input = characterController.Input;
            return input.Left || input.Right || input.Down || input.Up;
        }
    }
}
