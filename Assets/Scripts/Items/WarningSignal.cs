using Assets.Scripts.Character;
using Assets.Scripts.EventSystem.Events;
using UnityEngine;

namespace Assets.Scripts.Items
{
    [RequireComponent(typeof(SpriteRenderer))]
    internal class WarningSignal : BehaviourBase
    {
        [SerializeField]
        private GameObject _lightSource;

        [SerializeField]
        private Material _defaultSpriteMaterial;

        [SerializeField, Range(0f,10f)]
        private float _signalTime;

        [SerializeField, Range(0f, 1000f)]
        private float _rotationSpeed;

        private SpriteRenderer _signalSprite;
        private Material _diffuseMaterial;

        private float _timer;
        private IGameTime _gameTime;

        void Awake()
        {
            _signalSprite = GetComponent<SpriteRenderer>();
            _diffuseMaterial = _signalSprite.material;
            _lightSource.SetActive(false);
            _gameTime = GetInstance<IGameTime>();
        }

        void OnEnable()
        {
            Subscribe<NewRoundStartedEvent>(OnNewRound);
        }

        void OnDisable()
        {
            Unsubscribe<NewRoundStartedEvent>(OnNewRound);
        }

        private void OnNewRound(NewRoundStartedEvent obj)
        {
            _signalSprite.material = _defaultSpriteMaterial;
            _lightSource.SetActive(true);
            _timer = _signalTime;
        }

        void Update()
        {
            _timer -= _gameTime.DeltaTime;
            _lightSource.transform.Rotate(new Vector3(_rotationSpeed * _gameTime.DeltaTime, 0, 0));
            if (_timer <= 0f)
            {
                _signalSprite.material = _diffuseMaterial;
                _lightSource.SetActive(false);
            }
        }

    }
}
