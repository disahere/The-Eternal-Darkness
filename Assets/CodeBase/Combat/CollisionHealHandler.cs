using UnityEngine;

namespace CodeBase.Combat
{
    public class CollisionHealHandler : MonoBehaviour
    {
        public int collisionHeal;

        private void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.gameObject.CompareTag("Player"))
            {
                var health = coll.gameObject.GetComponent<Health>();
                if (health != null)
                {
                    health.SetHealth(collisionHeal);
                    Destroy(gameObject);
                }
            }
        }
    }
}