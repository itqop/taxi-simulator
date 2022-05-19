using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCircle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotationY = Quaternion.AngleAxis(2,Vector3.forward);
        transform.rotation *= rotationY;
    }
}
