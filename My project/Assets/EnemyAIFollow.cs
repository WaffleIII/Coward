using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIFollow : MonoBehaviour
{
    public float speed;
    public float lineOfSight;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector2.Distance(player.position, transform.position);

        if (Distance < lineOfSight)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }
}
