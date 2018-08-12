using Assets.Scripts.Character;
using Assets.Scripts.EventSystem.Events;
using UnityEngine;

namespace Assets.Scripts.Cameras
{
    public class CameraShake : BehaviourBase
    {
        [SerializeField]
        private float _strenght = 1.4f;
        [SerializeField]
        private float _shakeTimer = 1f;

        private float _timer;
        private Vector3 _position;
        private bool _shaking;
        private IGameTime _gameTime;

        void Awake()
        {
            _gameTime = GetInstance<IGameTime>();
        }

        void OnEnable()
        {
            Subscribe<CarryableItemHitGroundEvent>(OnHitGround);
        }

        void OnDisable()
        {
            Unsubscribe<CarryableItemHitGroundEvent>(OnHitGround);
        }

        private void OnHitGround(CarryableItemHitGroundEvent obj)
        {
            _position = transform.position;
            _timer = _shakeTimer;
            _shaking = true;
        }

        void LateUpdate()
        {
            if (!_shaking)
            {
                return;
            }

            _timer -= _gameTime.DeltaTime;
            if (_timer <= 0f)
            {
                _shaking = false;
                transform.position = _position;
            }
            transform.localPosition = _position + (Random.insideUnitSphere * _strenght);
        }
    }
}
