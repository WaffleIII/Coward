using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBullet : MonoBehaviour
{
    public int damage;

    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Destroy(this.gameObject, 1.5f);
    }

    // Checks if the bullet collides with the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            target.GetComponent<PlayerHealth>().Damage(damage);
            Destroy(this.gameObject);
        }
    }
}
