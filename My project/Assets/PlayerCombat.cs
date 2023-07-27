using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform enemy;
    Vector3 currentDirection;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public float attackRate = 2f;
    private float nextAttack = 0f;

    public float attackDistance;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttack)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        // Find a way to work this into all enemies (using enemy layers) and not just one set enemy please
        float attackDistance = Vector3.Distance(enemy.transform.position, transform.position);
        
        if (attackDistance <= 3)
        {
            if (currentDirection == transform.right)
            {
                // Play the animation
                Debug.Log("Frontstab played!");
            }
            else if (currentDirection == -transform.right)
            {
                // Play the backstab animation
                Debug.Log("Backstab played!");
            }
        }

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
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
