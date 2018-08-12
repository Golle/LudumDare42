using Assets.Scripts.Character.Walking;
using Assets.Scripts.Framework;
using Assets.Scripts.Framework.Input;
using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Character
{
    internal class CharacterManager : BehaviourBase, ICharacterController
    {
        public IInputHandler Input { get; private set; }
        public IAnimationParameters AnimationParameters { get; private set; }
        public IGameTime GameTime { get; private set; }
        public IMovement Movement { get; private set; }
        public ICarrying Carrying { get; private set; }

        [SerializeField]
        private CharacterState _initialState;

        private CharacterState _currentState;
        private CharacterState _nextState;

        void Awake()
        {
            Input = GetInstance<IInputHandler>();
            GameTime = GetInstance<IGameTime>();
            Movement = GetComponent<IMovement>();
            AnimationParameters = GetComponent<IAnimationParameters>();
            Carrying = GetComponentInChildren<ICarrying>();
        }
        void Start()
        {
            _nextState = _initialState;
        }

        void Update()
        {

            if (_nextState != null)
            {
                _currentState = _nextState;
                _currentState.OnEnter(this);
                _nextState = null;
            }
            _currentState.OnUpdate(this);
            if (_nextState != null)
            {
                _currentState.OnLeave(this);
            }
        }

        public void ChangeState(CharacterState nextState)
        {
            _nextState = nextState;
        }
    }
}
