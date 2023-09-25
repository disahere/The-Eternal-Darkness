using UnityEngine;

namespace CodeBase.World
{
    [RequireComponent(typeof(AudioSource))]
    public class Sounds : MonoBehaviour
    {
        private AudioSource _audioSource;
        private bool _isPlayerInside;
        private float _timeInside;

        [SerializeField] private bool playContinuously = true;
        [SerializeField] private float timeThreshold = 2f;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Play();
            _audioSource.Pause();
        }

        private void Update()
        {
            if (_isPlayerInside || playContinuously)
            {
                if (!_isPlayerInside) return;
                _timeInside += Time.deltaTime;
                if (_timeInside >= timeThreshold)
                {
                    _audioSource.UnPause();
                }
            }
            else
            {
                _timeInside = 0f;
                _audioSource.Pause();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _isPlayerInside = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            _isPlayerInside = false;
            _timeInside = 0f;
        }
    }
}