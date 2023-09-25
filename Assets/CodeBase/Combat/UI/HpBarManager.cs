using UnityEngine;

namespace CodeBase.Combat.UI
{
    public class HpBarManager : MonoBehaviour
    {
        [SerializeField] private GameObject hpBarPrefab;

        private void Start()
        {
            var healthComponents = FindObjectsOfType<Health.Health>();

            foreach (var healthComponent in healthComponents)
            {
                if (!healthComponent.CompareTag("Enemy")) continue;
                var hpBarInstance = Instantiate(hpBarPrefab, transform);
                var hpBarUpdater = hpBarInstance.GetComponent<HpBarUpdater>();
                    
                if (hpBarUpdater != null)
                {
                    hpBarUpdater.health = healthComponent;
                }
            }
        }
    }
}