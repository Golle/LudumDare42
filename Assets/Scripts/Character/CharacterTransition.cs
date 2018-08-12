using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Character
{
    [CreateAssetMenu(menuName = "Custom/State Machine/Transition")]
    internal class CharacterTransition : ScriptableObject
    {
        [SerializeField]
        private CharacterDecision _decision;

        [SerializeField]
        private CharacterState _nextState;

        public bool OnUpdate(ICharacterController controller)
        {
            if (_decision.ChangeState(controller))
            {
                controller.ChangeState(_nextState);
                return true;
            }
            return false;
        }

        public void OnEnter(ICharacterController controller)
        {
            _decision.Setup(controller);
        }

        public void OnLeave(ICharacterController controller)
        {
            _decision.Teardown(controller);
        }
    }
}