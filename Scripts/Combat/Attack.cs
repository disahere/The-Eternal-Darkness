using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attacklPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    void Update(){

        if (timeBtwAttack <= 0) {        
         if (Input.GetKey(KeyCode.Space)) { 
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attacklPos.position, attackRange, whatIsEnemies); {

            }
         }
         timeBtwAttack = startTimeBtwAttack;
           }   else  {
        timeBtwAttack -= Time.deltaTime;
           }
        }
            void OnDrawGizmosSelected(){
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(attacklPos.position, attackRange);
        }
    
}
