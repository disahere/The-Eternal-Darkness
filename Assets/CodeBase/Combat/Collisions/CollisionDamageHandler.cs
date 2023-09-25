using UnityEngine;
using CodeBase.Interfaces;

namespace CodeBase.Combat.Collisions
{
    internal class CollisionDamageHandler : MonoBehaviour
    {
        [SerializeField] private int collisionDamage;
        [SerializeField] private string allowedTags;

        private void OnCollisionEnter2D(Collision2D coll)
        {
            var collisionHandler = coll.gameObject.GetComponent<ICollisionHandler>();
            collisionHandler?.HandleCollision(coll.collider, collisionDamage, allowedTags);
        }
    }
}