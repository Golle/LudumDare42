using Assets.Scripts.Items;
using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts
{
    internal class Dropzone : BehaviourBase
    {
        [SerializeField, Range(-20f, 20f)]
        private float _force;

        [SerializeField]
        private Vector2 _spawnOffset;
        public void DropItem(CarryableItem item)
        {
            item.transform.SetParent(transform);
            item.transform.localPosition = _spawnOffset;
            item.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _force);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position + transform.rotation * (Vector3)_spawnOffset, 0.5f);
        }
    }
}
