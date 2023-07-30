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
    private float directionFaced;

    public bool Attacking = false;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttack && !Attacking)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attacking = true;
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

            directionFaced = Input.GetAxisRaw("Horizontal");
            float attackDistance = Vector3.Distance(enemy.transform.position, transform.position);
        }

        if (attackDistance <= 3)
        {
            if (directionFaced == 1)
            {
                // Play the animation
                Debug.Log("Frontstab played!");
            }
            else if (directionFaced == -1)
            {
                // Play the backstab animation
                Debug.Log("Backstab played!");
            }
        }

        StartCoroutine(EndAttack());
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    //This is just for animations for now
    private IEnumerator EndAttack()
    {
        yield return new WaitForSeconds(0.5f);
        Attacking = false;
    }
}
