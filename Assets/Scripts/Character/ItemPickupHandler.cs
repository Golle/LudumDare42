using Assets.Scripts.Framework.Input;
using Assets.Scripts.Items;
using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Character
{
    internal class ItemPickupHandler : BehaviourBase
    {
        [SerializeField]
        private GameObject _character;

        [SerializeField]
        private float _maxDistance = 1.4f;

        [SerializeField]
        private float _clickRadius = 2f;

        private IInputHandler _input;
        private ICharacterController _characterController;

        void Awake()
        {
            _input = GetInstance<IInputHandler>();
            _characterController = _character.GetComponent<ICharacterController>();
        }
        
        void Update()
        {
            if (_input.Pickup)
            {
                var worldPosition = Camera.main.ScreenToWorldPoint(_input.MousePosition);
                if(Vector2.Distance(worldPosition, _character.transform.position) <= _clickRadius)
                {
                    TryToPickupOrDropItem(ref worldPosition);
                }
            }
        }

        private void TryToPickupOrDropItem(ref Vector3 position)
        {
            var hits = Physics2D.RaycastAll(position, Vector2.zero);
            foreach (var hit in hits)
            {
                if (hit.transform == null)
                {
                    continue;
                }

                if (hit.transform.tag == "CarryableItem")
                {
                    if (Vector2.Distance(hit.transform.position, _character.transform.position) <= _maxDistance)
                    {
                        var carryableItem = hit.transform.gameObject.GetComponent<CarryableItem>();
                        _characterController.Carrying.Pickup(carryableItem);
                    }
                }
                if (hit.transform.tag == "Dropzone")
                {
                    var dropZone = hit.transform.gameObject.GetComponent<Dropzone>();
                    _characterController.Carrying.DropAt(dropZone);
                }
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_character.transform.position, _maxDistance);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_character.transform.position, _clickRadius);
        }
    }
}
