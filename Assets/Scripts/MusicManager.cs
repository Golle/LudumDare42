using Assets.Scripts.EventSystem.Events;
using Assets.Scripts.Variables;
using UnityEngine;
#pragma warning disable 649

namespace Assets.Scripts
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : BehaviourBase
    {

        [SerializeField]
        private MusicCollection _musicCollection;

        private AudioSource _audioSource;

        void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        void OnEnable()
        {
            Subscribe<GameStartedEvent>(OnGameStarted);
            Subscribe<GameFinishedEvent>(OnGameFinished);
        }

        void OnDisable()
        {
            Unsubscribe<GameStartedEvent>(OnGameStarted);
            Unsubscribe<GameFinishedEvent>(OnGameFinished);
        }

        private void OnGameFinished(IEvent obj)
        {
            _audioSource.Stop();
            
        }

        private void OnGameStarted(IEvent obj)
        {
            _audioSource.clip = _musicCollection.Clips[Random.Range(0, _musicCollection.Clips.Length-1)];
            _audioSource.volume = _musicCollection.Volume;
            _audioSource.Play();
        }
    }
}
