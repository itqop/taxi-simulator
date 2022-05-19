using Cinemachine;
using UnityEngine;

public class CameraChangePos : MonoBehaviour
{
    private CinemachineFreeLook cam;
    public Transform CubeCar;
    private void Start()
    {
        cam = GetComponent<CinemachineFreeLook>();
    }

    private void FixedUpdate()
    {
        CubeCar = GameObject.FindWithTag("CameraPos").transform;
        cam.Follow = CubeCar;
        cam.LookAt = CubeCar;
    }
}
