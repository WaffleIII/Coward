using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public GameObject player;

    public float health;
    float maxHealth = 100;
    float lerpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColourChanger();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = health / 100;
    }

    void ColourChanger()
    {
        Color healthColour = Color.Lerp(Color.red, Color.green, (health / maxHealth));

        healthBar.color = healthColour;
    }

    public void Damage(float damagePoints)
    {
        health -= damagePoints;

        if (health < 0)
        {
            Die();
        }
    }

    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
        {
            health += healingPoints;
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
