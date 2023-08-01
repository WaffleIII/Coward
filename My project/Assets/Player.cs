using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHP;
    public int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP; 
    }

    private void Update()
    {
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        // Play hurt animation

        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Heal(int healingPoints)
    {
        //// Detect enemies in range of attack
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(this.transform.position, healingRange, enemyLayers);
        

        //// Damage them
        //foreach (Collider2D enemy in hitEnemies)
        //{
        //    float Distance = Vector2.Distance(enemy.transform.position, transform.position);

        //    if (Distance >= healingRange)
        //    {
                currentHP += healingPoints;
            //}
       // }
    }

    void Die()
    {
        // Play death animation
        // Wait a few seconds then switch to restart screen or whatever game over screen we make

        GetComponent<Collider2D>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GetComponent<PlayerCombat>().enabled = false;
        GetComponent<PlayerHealth>().enabled = false;
        this.enabled = false;
        Destroy(gameObject, 3);
    }
}