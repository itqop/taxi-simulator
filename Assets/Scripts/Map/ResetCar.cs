using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCar : MonoBehaviour
{
    private Cont rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Cont>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("resetcar"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            var rotationVector = transform.rotation.eulerAngles;
            rotationVector.z = 0;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
    }
}
