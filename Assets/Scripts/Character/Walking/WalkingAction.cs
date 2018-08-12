using UnityEngine;

namespace Assets.Scripts.Character.Walking
{
    [CreateAssetMenu(menuName = "Custom/State Machine/Walking Action")]
    internal class WalkingAction : CharacterAction
    {
        [SerializeField]
        private float _speed;
        public override void OnEnter(ICharacterController controller)
        {
            controller.AnimationParameters.SetBool("Walking", true);
        }

        public override void OnUpdate(ICharacterController controller)
        {
            var input = controller.Input;
            var direction = Vector2.zero;
            if (input.Down)
            {
                direction.y -= 1;
            }
            if (input.Up)
            {
                direction.y += 1;
            }
            if (input.Left)
            {
                direction.x -= 1;
            }
            if (input.Right)
            {
                direction.x += 1;
            }
            controller.Movement.Move(direction.normalized * _speed * controller.GameTime.DeltaTime);
        }

        public override void OnLeave(ICharacterController controller)
        {
            controller.AnimationParameters.SetBool("Walking", false);
        }
    }
}