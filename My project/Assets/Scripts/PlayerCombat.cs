using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public LayerMask enemyLayers;

    [Header("Attacking")]
    public float attackRange = 0.5f;
    public int attackDamage = 10;
    private float directionFaced;
    public bool Attacking = false;

    // Update is called once per frame
    void Update()
    {
        if (!Attacking && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
    }

    void Attack()
    {
        Attacking = true;

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

            directionFaced = Input.GetAxisRaw("Horizontal");
            float attackDistance = Vector3.Distance(enemy.transform.position, transform.position);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
