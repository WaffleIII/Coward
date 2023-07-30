using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBurstShot : MonoBehaviour
{
    public float speed;
    public float lineOfSight;
    public float shootingRange;
    public float fireRate = 0.1f;
    private float nextFireTime;
    private float reloadTime = 0f;
    private float fireNumber;
    public float maxFireNumber = 5;

    public GameObject bullet;
    public GameObject bulletParent;

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

        if (Distance < lineOfSight && Distance > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Distance <= shootingRange && nextFireTime < Time.time && reloadTime <= 0)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextFireTime = Time.time + fireRate;
            fireNumber += 1;

            if (fireNumber == maxFireNumber)
            {
                reloadTime = 2f;
                StartCoroutine(Reload());
            }  
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        reloadTime = 0f;
        fireNumber = 0f;
    }
}
