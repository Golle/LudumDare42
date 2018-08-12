
using System;
using System.Collections.Generic;
using Assets.Scripts.Items;
using UnityEngine;
using Random = UnityEngine.Random;
#pragma warning disable 649

namespace Assets.Scripts.Level
{
    [Serializable]
    internal class Level : ILevel
    {
        [SerializeField]
        private ItemCollection _items;
        [SerializeField]
        private float _timeBetweenRounds;
        [SerializeField]
        private int _rounds;
        [SerializeField]
        private int _minItems;
        [SerializeField]
        private int _maxItems;

        public int Rounds => _rounds;
        public float TimeBetweenRounds => _timeBetweenRounds;

        public IEnumerable<IItem> GetRandomItems(int additionalItems)
        {
            var items = Random.Range(_minItems, _maxItems) + additionalItems;
            for (var i = 0; i < items; ++i)
            {
                yield return _items.GetRandomItem();
            }
        }
    }
}