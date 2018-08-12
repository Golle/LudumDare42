using UnityEngine;

namespace Assets.Scripts.Character.Walking
{
    internal class CharacterMovement : BehaviourBase, IMovement
    {
        private Transform _transform;
        private Animator _animator;

        void Awake()
        {
            _animator = GetComponent<Animator>();
            _transform = transform;
        }


        public void Move(Vector2 distance)
        {
            if (distance != Vector2.zero)
            {
                _transform.Translate(distance);
                var normalizedDistance = distance.normalized;
                if (normalizedDistance.x > 0.01f || normalizedDistance.x < -0.01f)
                {
                    _animator.SetFloat("DirectionX", normalizedDistance.x);
                }
            }
        }
    }
}