using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator anim;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int slashDamage = 20;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime) {
            if(Input.GetKeyDown("z")) {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        
    }

    void Attack() {

        anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            Debug.Log("Hit");

            enemy.GetComponent<Enemy>().TakeDamage(slashDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) { return; }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
