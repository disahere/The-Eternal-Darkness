using UnityEngine;
using CodeBase.Interfaces;

namespace CodeBase.Combat
{
    public class Health : MonoBehaviour, ICollisionHandler
    {
        public int HealthValue => health;
        public int MaxHealth => maxHealth;

        [SerializeField] private int health;
        [SerializeField] private int maxHealth;

        private void Start()
        {
            health = maxHealth;
        }

        public void TakeHit(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void SetHealth(int bonusHealth)
        {
            health += bonusHealth;

            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }

        public void HandleCollision(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player") || collider.gameObject.CompareTag("Enemy"))
            {
                CollisionDamageHandler damageHandler = collider.gameObject.GetComponent<CollisionDamageHandler>();
                if (damageHandler != null)
                {
                    TakeHit(damageHandler.collisionDamage);
                }

                CollisionHealHandler healHandler = collider.gameObject.GetComponent<CollisionHealHandler>();
                if (healHandler != null)
                {
                    SetHealth(healHandler.collisionHeal);
                }
            }
        }

        private void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}