using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheck : MonoBehaviour
{
    public GameObject tp;
    private bool hasSpawned = false;

    private void Update()
    {
        GameObject[] EnemysLeft = GameObject.FindGameObjectsWithTag("Enemy");

        if (EnemysLeft.Length <= 0 && !hasSpawned)
        {
            Debug.Log("YOU KILLED THEM ALL >:(");
            Instantiate(tp, new Vector3(-6.81f, -3.62f, 0f), Quaternion.identity);
            hasSpawned = true;
            
        }
    }
}