using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    public int maxHP = 10;
    private int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        // Play hurt animation

        if (currentHP <= 0)
        {
            Debug.Log("Enemy Destroyed!");
            Die();
        }
    }

    void Die()
    {
        // Play death animation

        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyAIFollow>().enabled = false;
        this.enabled = false;
        Destroy(gameObject, 3);
    }
}