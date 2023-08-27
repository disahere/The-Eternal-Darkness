using CodeBase.World;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Player
{
    public class PlayerTeleport : MonoBehaviour
    {
        [SerializeField] private Button teleportButton;
        private GameObject _currentTeleport;
        private Teleport _teleport;
        
        private bool _isButtonEnabled = true;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.CompareTag("Teleport")) return;
            _currentTeleport = collision.gameObject;
            _teleport = _currentTeleport.GetComponent<Teleport>();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (!collision.CompareTag("Teleport")) return;
            if (collision.gameObject != _currentTeleport) return;
            _currentTeleport = null;
            _teleport = null;
        }

        private void Start()
        {
            _currentTeleport = null;
            _teleport = null;

            teleportButton.onClick.AddListener(TeleportButtonClicked);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TryTeleport();
            }
        }

        private void TryTeleport()
        {
            if (!_isButtonEnabled)
                return;

            if (_teleport != null)
            {
                transform.position = _teleport.GetDestination().position;
            }
        }

        public void TeleportButtonClicked()
        {
            TryTeleport();

            StartCoroutine(EnableButtonAfterDelay(1f));
        }

        private System.Collections.IEnumerator EnableButtonAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            _isButtonEnabled = true;
        }
    }
}