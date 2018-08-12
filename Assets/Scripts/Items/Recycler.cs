using Assets.Scripts.EventSystem.Events;
using UnityEngine;

namespace Assets.Scripts.Items
{
    [RequireComponent(typeof(Collider2D))]
    internal class Recycler : BehaviourBase
    {
        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.transform.tag == "CarryableItem")
            {
                var carryableItem = collider2D.transform.GetComponent<CarryableItem>();
                if (carryableItem.Item is RecyclableItem)
                {
                    RaiseEvent(new ItemRecycledEvent());
                }
                else
                {
                    RaiseEvent(new BurnableItemRecycledEvent(carryableItem.Item));
                }
                Destroy(collider2D.gameObject);
            }
        }
    }
}