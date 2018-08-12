using Assets.Scripts.Character.Walking;
using Assets.Scripts.Framework;
using Assets.Scripts.Framework.Input;

namespace Assets.Scripts.Character
{
    internal interface ICharacterController
    {
        void ChangeState(CharacterState nextState);
        IInputHandler Input { get; }
        IAnimationParameters AnimationParameters { get; }
        IGameTime GameTime { get; }
        IMovement Movement { get; }
        ICarrying Carrying { get; }
    }
}