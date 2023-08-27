using UnityEngine;
using UnityEngine.UI;
using CodeBase.Interfaces;

namespace CodeBase.Inventory
{
    public class InventoryOpener : MonoBehaviour, IInventoryOpener
    {
        private GameObject _inventoryRef;
        private bool _inventoryOpened;
        private bool _wasOpenedBefore;
        private bool _isButtonEnabled = true;

        public Button inventoryButton;

        private void Start()
        {
            _inventoryRef = GameObject.Find("Inventory");
            _inventoryRef.SetActive(false);

            inventoryButton.onClick.AddListener(OpenOrCloseInventory);
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                OpenOrCloseInventory();
            }
        }

        public void OpenOrCloseInventory()
        {
            if (!_isButtonEnabled)
                return;

            _isButtonEnabled = false;

            if (!_inventoryOpened && !_wasOpenedBefore)
            {
                OpenInventory();
                _wasOpenedBefore = true;
            }
            else
            {
                CloseInventory();
                _wasOpenedBefore = false;
            }

            StartCoroutine(EnableButtonAfterDelay(1f));
        }

        private System.Collections.IEnumerator EnableButtonAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            _isButtonEnabled = true;
        }

        public void OpenInventory()
        {
            _inventoryRef.SetActive(true);
            _inventoryOpened = true;
        }

        public void CloseInventory()
        {
            _inventoryRef.SetActive(false);
            _inventoryOpened = false;
        }
    }
}