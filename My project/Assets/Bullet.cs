using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public GameObject bullet;

    GameObject target;
    Rigidbody2D Bulletrb;

    // Start is called before the first frame update
    void Start()
    {
        Bulletrb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        Bulletrb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 3);
        bullet = GameObject.Find("Bullet(Clone)");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            target.GetComponent<Player>().TakeDamage(damage);
            target.GetComponent<PlayerHealth>().Damage(damage);
            Destroy(bullet, 3);
        }
    }
}
