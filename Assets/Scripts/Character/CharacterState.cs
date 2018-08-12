using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Character
{
    [CreateAssetMenu(menuName = "Custom/State Machine/State")]
    internal class CharacterState : ScriptableObject
    {
        [SerializeField]
        private CharacterTransition[] _transitions;

        [SerializeField]
        private CharacterAction[] _actions;

        public void OnEnter(ICharacterController characterController)
        {
            foreach (var characterAction in _actions)
            {
                characterAction.OnEnter(characterController);
            }
            foreach (var characterTransition in _transitions)
            {
                characterTransition.OnEnter(characterController);
            }
        }

        public void OnLeave(ICharacterController characterController)
        {
            foreach (var characterAction in _actions)
            {
                characterAction.OnLeave(characterController);
            }
            foreach (var characterTransition in _transitions)
            {
                characterTransition.OnLeave(characterController);
            }
        }

        public void OnUpdate(ICharacterController characterController)
        {
            foreach (var characterAction in _actions)
            {
                characterAction.OnUpdate(characterController);
            }
            foreach (var characterTransition in _transitions)
            {
                if (characterTransition.OnUpdate(characterController))
                {
                    return;
                }
            }
        }
    }
}