using Assets.Scripts.Character;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 649

namespace Assets.Scripts.Hud
{
    internal class MovingText : BehaviourBase
    {
        private Text _textField;

        [SerializeField]
        private float _distance;

        [SerializeField]
        private float _smooth;

        private float _time;
        private IGameTime _gameTime;
        private Vector2 _destination;
        private bool _initialized;

        void Awake()
        {
            _gameTime = GetInstance<IGameTime>();
            _textField = GetComponent<Text>();
        }
        public void Initialize(string text, float time)
        {
            _textField.text = text;
            _time = time;
            _destination = new Vector2(transform.position.x, transform.position.y + _distance);
            _initialized = true;
        }

        void Update()
        {
            if (!_initialized)
            {
                return;
            }
            _time -= _gameTime.DeltaTime;
            transform.position += new Vector3(0f, _smooth * _gameTime.DeltaTime);
            if (_time <= 0f)
            {
                Destroy(gameObject);
            }
        }

    }
}