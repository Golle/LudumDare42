using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Level
{
    [CreateAssetMenu(menuName = "Custom/Level/Level Descriptor")]
    internal class LevelDescriptor : ScriptableObject
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private Level[] _level;
        public ILevel[] Level => _level;
    }
}