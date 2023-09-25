using UnityEngine;
using CodeBase.Interfaces;
using UnityEngine.SceneManagement;

namespace CodeBase.Combat.Health
{
    public class Health : MonoBehaviour, ICollisionHandler
    {
        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth;

        public int HealthValue => currentHealth;
        public int MaxHealth => maxHealth;

        private void Start()
        {
            currentHealth = maxHealth; 
        }

        public void TakeHit(int damage)
        {
            currentHealth -= damage;

            if (currentHealth > 0) return;
            if (gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }

        public void SetHealth(int bonusHealth)
        {
            currentHealth += bonusHealth;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        public void HandleCollision(Collider2D otherCollider, int damage, string allowedTags)
        {
            if (!IsTagAllowed(otherCollider.tag, allowedTags)) return;
            if (otherCollider.CompareTag("Player"))
            {
                TakeHit(damage);
            }
            else if (otherCollider.CompareTag("Enemy"))
            {
                var enemyHealth = otherCollider.gameObject.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeHit(damage);
                }
            }
        }

        private static bool IsTagAllowed(string otherTag, string allowedTags)
        {
            return allowedTags.Contains(otherTag);
        }
    }
}