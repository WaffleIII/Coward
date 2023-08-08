using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Player;
    public Transform Camera;

    [Header("Offset")]
    public float XOffset;
    public float YOffset;

    void Update()
    {
        Camera.position = new Vector3(Player.position.x + XOffset, Player.position.y + YOffset, -3);
    }
}
