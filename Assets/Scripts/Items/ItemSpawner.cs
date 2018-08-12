using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.EventSystem.Events;
using UnityEngine;
using UnityEngine.Tilemaps;

#pragma warning disable 649

namespace Assets.Scripts.Items
{
    internal class ItemSpawner : BehaviourBase
    {
        [SerializeField]
        private CarryableItem _carryableItemPrefab;
        [SerializeField]
        private GameObject _shadowPrefab;
        [SerializeField]
        private Tilemap _tilemap;

        private CarryableItem[,] _itemSlots;
        private GameObject[,] _shadows;
        private Vector2 _startPosition;

        [SerializeField, Range(10f, 100f)]
        private float _dropDistance;

        public void OnEnable()
        {
            Subscribe<CarryableItemPickedUpEvent>(OnItemPickedUp);
            Subscribe<NewRoundStartedEvent>(OnNewRound);
        }

        public void OnDisable()
        {
            Unsubscribe<CarryableItemPickedUpEvent>(OnItemPickedUp);
            Unsubscribe<NewRoundStartedEvent>(OnNewRound);

        }
        private void OnNewRound(NewRoundStartedEvent @event)
        {
            foreach (var item in @event.Items)
            {
                SpawnItem(item);
            }
        }

        private void OnItemPickedUp(CarryableItemPickedUpEvent @event)
        {
            var item = @event.Item;
            for (var x = 0; x < _itemSlots.GetLength(0); ++x)
            {
                for (var y = 0; y < _itemSlots.GetLength(1); ++y)
                {
                    if (_itemSlots[x, y] == item)
                    {
                        _itemSlots[x, y] = null;
                        Destroy(_shadows[x, y]);
                        _shadows[x, y] = null;
                    }
                }
            }
            CheckTrash();
        }

        private void CheckTrash()
        {
            foreach (var carryableItem in _itemSlots)
            {
                if (carryableItem != null)
                {
                    return;
                }
            }
            RaiseEvent(new OutOfTrashEvent());
        }

        void Awake()
        {
            _itemSlots = new CarryableItem[_tilemap.size.x-2, _tilemap.size.y-2];
            _shadows = new GameObject[_tilemap.size.x-2, _tilemap.size.y-2];
            _startPosition = _tilemap.CellToWorld(_tilemap.cellBounds.min) + new Vector3(1.5f, 1.5f, 0f);
        }

        private void SpawnItem(IItem item)
        {
            var freeSlots = GetEmptySlots().ToArray();
            if (freeSlots.Length == 0)
            {
                RaiseEvent(new OutOfSpaceEvent());
            }
            else
            {
                var position = freeSlots[Random.Range(0, freeSlots.Length)];
                var carryableItem = Instantiate(_carryableItemPrefab, transform);
                var destination = new Vector2(position.x, position.y) + _startPosition;
                
                carryableItem.Initialize(item, destination, Random.Range(10f, _dropDistance));
                _itemSlots[position.x, position.y] = carryableItem;

                var shadow = Instantiate(_shadowPrefab, transform);
                _shadows[position.x, position.y] = shadow;
                shadow.transform.position = destination;

                RaiseEvent(new CarryableItemSpawnedEvent(carryableItem));
            }
        }
        private IEnumerable<Vector2Int> GetEmptySlots()
        {
            for (var x = 0; x < _itemSlots.GetLength(0); ++x)
            {
                for (var y = 0; y < _itemSlots.GetLength(1); ++y)
                {
                    if (_itemSlots[x, y] == null)
                    {
                        yield return new Vector2Int(x, y);
                    }
                }
            }
        }
    }
}
