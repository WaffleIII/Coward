using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheck : MonoBehaviour
{
    private void Update()
    {
        GameObject[] EnemysLeft = GameObject.FindGameObjectsWithTag("Enemy");

        if (EnemysLeft.Length <= 0)
        {
            Debug.Log("YOU KILLED THEM ALL >:(");
        }
    }
}
