using UnityEngine;

namespace CodeBase.Combat.Collisions
{
    public class CollisionHealHandler : MonoBehaviour
    {
        [SerializeField] private int collisionHeal;

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (!coll.gameObject.CompareTag("Player")) return;
            var health = coll.gameObject.GetComponent<Health.Health>();
            if (health == null || health.HealthValue >= health.MaxHealth) return;
            health.SetHealth(collisionHeal);
            Destroy(gameObject);
        }
    }
}