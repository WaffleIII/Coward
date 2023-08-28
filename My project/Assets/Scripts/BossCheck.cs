using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCheck : MonoBehaviour
{
    public LayerMask layerToCheck;

    private void Update()
    {
        GameObject[] objectsInLayer = FindObjectsOfType<GameObject>();

        bool allDestroyed = true;

        foreach (GameObject obj in objectsInLayer)
        {
            if (obj.layer == layerToCheck && obj.activeSelf)
            {
                allDestroyed = false;
                break;
            }
        }

        if (allDestroyed)
        {
            // All objects in the layer have been destroyed
            Debug.Log("All objects in the layer have been destroyed.");
        }
    }
}
