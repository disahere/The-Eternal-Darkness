using UnityEngine;

namespace CodeBase.Combat
{
    public class Attack : MonoBehaviour
    {
        public Transform attackPos;
        public LayerMask whatIsEnemies;
        public float attackRange;
        public int damage;
        public float timeBtwAttacks = 0.5f;

        private float _currentTimeBtwAttacks;

        private void Update()
        {
            _currentTimeBtwAttacks -= Time.deltaTime;

            if (_currentTimeBtwAttacks <= 0 && Input.GetKeyDown(KeyCode.Space))
            {
                PerformAttack();
                _currentTimeBtwAttacks = timeBtwAttacks;
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void PerformAttack()
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

            foreach (Collider2D enemyCollider in enemiesToDamage)
            {
                Health enemyHealth = enemyCollider.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeHit(damage);
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (attackPos == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position, attackRange);
        }

        public void PerformAttackOnClick()
        {
            if (_currentTimeBtwAttacks <= 0)
            {
                PerformAttack();
                _currentTimeBtwAttacks = timeBtwAttacks;
            }
        }
    }
}