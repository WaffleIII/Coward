using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    GameObject target;
    Rigidbody2D Bulletrb;

    // Start is called before the first frame update
    void Start()
    {
        Bulletrb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        Bulletrb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 5);
    }
}
