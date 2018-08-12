using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Cameras
{
    [RequireComponent(typeof(Camera))]
    internal class FollowCamera : BehaviourBase
    {
        private Camera _camera;
        [SerializeField]
        private string _characterTag;
        [SerializeField]
        private UnityEngine.Tilemaps.Tilemap _world;
        [SerializeField]
        private float _smooth;

        [SerializeField]
        private Vector2 _offset = Vector2.zero;

        private GameObject _character;
        private Transform _characterTransform;

        private float _leftBound;
        private float _rightBound;
        private float _topBound;
        private float _bottomBound;

        void Awake()
        {
            _camera = GetComponent<Camera>();
            var bounds = _world.localBounds;
            var verticalSize = _camera.orthographicSize;
            var horizontalSize = verticalSize * Screen.width / Screen.height;
            _leftBound = bounds.min.x + horizontalSize;
            _rightBound = bounds.max.x - horizontalSize;
            _bottomBound = bounds.min.y + verticalSize;
            _topBound = bounds.max.y - verticalSize;
        }

        void Start()
        {
            _character = GameObject.FindGameObjectWithTag(_characterTag);
            _characterTransform = _character.transform;
        }

        void Update()
        {
            var characterPosition = _characterTransform.position + (Vector3)_offset;
            transform.position = Vector3.Lerp(transform.position, GetPosition(ref characterPosition), _smooth);
        }

        private Vector3 GetPosition(ref Vector3 referencePosition)
        {
            var clampX = Mathf.Clamp(referencePosition.x, _leftBound, _rightBound);
            var clampY = Mathf.Clamp(referencePosition.y, _bottomBound, _topBound);
            return new Vector3(clampX, clampY, transform.position.z);
        }
    }
}