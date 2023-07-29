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

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        // Play hurt animation

        if (currentHP <= 0)
        {
            Die();
        }
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