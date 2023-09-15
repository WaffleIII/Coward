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

    [Header("X Scroll Speed")]
    public float MaxDistanceX;
    private float DirectionX;
    public float XScrollSpeed;

    void Update()
    {

        //MaxDistanceX = Input.GetAxisRaw("Horizontal");

        //Scrolling X
        if (DirectionX < MaxDistanceX && Input.GetAxisRaw("Horizontal") == 1)
        {
            DirectionX += XScrollSpeed;
        }
        else if (DirectionX > (MaxDistanceX * -1) && Input.GetAxisRaw("Horizontal") == -1)
        {
            DirectionX -= XScrollSpeed;
        }

        
        //Moves the thing
        Camera.position = new Vector3(Player.position.x + XOffset + DirectionX, Player.position.y + YOffset, -3);
    }
}
