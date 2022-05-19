using UnityEngine;

public class WheelMove : MonoBehaviour
{
    public Vector3 _rand;
    // Update is called once per frame
    public Rigidbody _rigidbody;
    
    void Update()
    {
        if (_rigidbody.velocity.magnitude != 0)
        {
            _rand = new Vector3(10f, 0f, 0f);
        }

        if (_rigidbody.velocity.magnitude == 0)
        {
            _rand = new Vector3(0f, 0f, 0f);
        }
        transform.Rotate(_rand * Time.deltaTime * 25);
    }
}
