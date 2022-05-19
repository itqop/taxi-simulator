using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterMass : MonoBehaviour
{
    public Transform _centerMass;
    private void Update()
    {
        GetComponent<Rigidbody>().centerOfMass = Vector3.Scale(_centerMass.localPosition,transform.localScale);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(GetComponent<Rigidbody>().worldCenterOfMass,0.1f);
    }
}
