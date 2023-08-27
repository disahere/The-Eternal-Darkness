using UnityEngine;
using CodeBase.Interfaces;

namespace CodeBase.Combat
{
    public class CollisionDamageHandler : MonoBehaviour
    {
        public int collisionDamage;
        public string collisionTag;

        private void OnCollisionEnter2D(Collision2D coll)
        {
            ICollisionHandler collisionHandler = coll.gameObject.GetComponent<ICollisionHandler>();
            if (collisionHandler != null && coll.gameObject.CompareTag(collisionTag))
            {
                collisionHandler.HandleCollision(coll.collider);
            }
        }
    }
}