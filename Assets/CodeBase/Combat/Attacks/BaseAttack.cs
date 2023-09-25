using UnityEngine;
using System.Collections.Generic;

namespace CodeBase.Combat.Attacks
{
    public class BaseAttack : MonoBehaviour
    {
        [SerializeField] protected Transform attackPos;
        [SerializeField] public List<string> enemyTags;
        [SerializeField] protected float attackRange;
        [SerializeField] protected int damage;
        [SerializeField] protected float timeBtwAttacks = 0.5f;

        private bool _isAttackPosNull;
        protected float currentTimeBtwAttacks;

        private void Start()
        {
            _isAttackPosNull = attackPos == null;
        }

        protected virtual void Update()
        {
            currentTimeBtwAttacks -= Time.deltaTime;
        }

        private void PerformAttackAction()
        {
            if (_isAttackPosNull) return;
            // ReSharper disable once Unity.PreferNonAllocApi
            var enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange);

            foreach (var enemyCollider in enemiesToDamage)
            {
                if (!enemyTags.Contains(enemyCollider.gameObject.tag)) continue;
                var enemyHealth = enemyCollider.GetComponent<Health.Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeHit(damage);
                }
            }
        }

        protected void OnDrawGizmosSelected()
        {
            if (attackPos == null) return;
            
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }

        public virtual void PerformAttack()
        {
            if (!(currentTimeBtwAttacks <= 0)) return;
            PerformAttackAction();
            currentTimeBtwAttacks = timeBtwAttacks;
        }
    }
}