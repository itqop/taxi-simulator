using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamFollow : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;

    private void Update()
    {
        Player = GameObject.Find("Car").transform;
        
        transform.position = Player.position + offset;

        Vector3 rot = new Vector3(90, Player.eulerAngles.y, 0);
        
        transform.rotation = Quaternion.Euler(rot);
    }
}
