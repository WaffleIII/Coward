using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAITrack : MonoBehaviour
{
    public float speed;
    public float lineOfSight;
    public float shootingRange;
    public float fireRate = 1f;
    private float nextFireTime;
    private float fireShot;

    public GameObject bullet;
    public GameObject trackMarker;
    private Vector3 trackpos;

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

        if (Distance <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(trackMarker, player.transform.position, Quaternion.identity);
            trackpos = player.transform.position;
            nextFireTime = Time.time + fireRate;
            StartCoroutine(FireBullet());
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    private IEnumerator FireBullet()
    {
        yield return new WaitForSeconds(2.5f);
        Instantiate(bullet, trackpos, Quaternion.identity);
    }
}
