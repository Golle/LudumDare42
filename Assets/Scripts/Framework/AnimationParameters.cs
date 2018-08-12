using UnityEngine;

namespace Assets.Scripts.Framework
{
    [RequireComponent(typeof(Animator))]
    internal class AnimationParameters : MonoBehaviour, IAnimationParameters
    {
        private Animator _animator;

        void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void SetBool(string id, bool value)
        {
            _animator.SetBool(id, value);
        }
        public void SetFloat(string id, float value)
        {
            _animator.SetFloat(id, value);
        }
    }
}