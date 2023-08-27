using UnityEngine;

namespace CodeBase.World
{
    [RequireComponent(typeof(AudioSource))]
    public class Sounds : MonoBehaviour
    {
        private AudioSource _audioSource;

        public void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play(0);
            _audioSource.Pause();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _audioSource.UnPause();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _audioSource.Pause();
            }
        }
    }
}