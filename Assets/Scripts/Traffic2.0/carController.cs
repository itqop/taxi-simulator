using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class carController : MonoBehaviour
{
    private Rigidbody rb;
    
    [SerializeField]
    private float power = 5;
    [SerializeField]
    private float torque = 0.5f;
    [SerializeField]
    private float maxSpeed = 5;
    [SerializeField]
    private Vector2 movementVector;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 movementInput)
    {
        this.movementVector = movementInput;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(movementVector.y * transform.forward * power);
        }
        rb.AddTorque(movementVector.x * torque * Vector3.up * movementVector.y);
    }
}
