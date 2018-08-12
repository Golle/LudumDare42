using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts.Variables
{
    [CreateAssetMenu(menuName = "custom/variables/Music Collection")]
    public class MusicCollection : ScriptableObject
    {
        [SerializeField]
        [Range(0f, 1f)]
        private float _volume;

        [SerializeField]
        private AudioClip[] _audioClips;

        public AudioClip[] Clips => _audioClips;
        public float Volume => _volume;
    }
}