using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Items
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    internal class CarryableItem : BehaviourBase
    {
        [SerializeField]
        private GameObject _mouseOverObject;

        private SpriteRenderer _spriteRenderer;
        private Collider2D _collider;
        private Rigidbody2D _rigidBody;
        private FallingItem _fallingItem;

        public IItem Item { get; private set; }
        public bool CanBePickedUp { get; private set; }
        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
            _rigidBody = GetComponent<Rigidbody2D>();
            CanBePickedUp = false;
            _fallingItem = GetComponent<FallingItem>();
            _collider.enabled = false;
        }

        public void Initialize(IItem item, Vector2 destination, float dropDistance)
        {
            Item = item;
            _spriteRenderer.sprite = Item.Sprite;
            transform.position = destination + new Vector2(0, dropDistance);
            _fallingItem.Initialize(destination, () =>
            {
                _collider.enabled = true;
                CanBePickedUp = true;
            });
        }

        void OnMouseEnter()
        {
            if (CanBePickedUp)
            { 
                _mouseOverObject.SetActive(true);
            }
        }

        void OnMouseExit()
        {
            _mouseOverObject.SetActive(false);
        }

        public void OnPickup()
        {
            _collider.enabled = false;
            _mouseOverObject.SetActive(false);
        }

        public void OnDrop()
        {
            _rigidBody.isKinematic = false;
            _collider.enabled = true;
            _collider.isTrigger = true;
            CanBePickedUp = false;
        }
    }
}