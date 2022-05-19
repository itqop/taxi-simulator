using UnityEngine;

public class Rotation : MonoBehaviour
{
    //! povorot objekta
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float hor = Input.GetAxis("Mouse X") * 10 * Mathf.Deg2Rad;
            transform.RotateAround(Vector3.up,-hor);
        }
        else
        {
            transform.RotateAround(transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }
}
