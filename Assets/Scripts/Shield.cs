
using System;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer != 6)
        {
            gameObject.SetActive(false);
        }
        
    }
}
