using UnityEngine;

public class unlockspeed : MonoBehaviour
{
    [SerializeField]
    private TrafficLight _tlight;

    private void Start()
    {
        _tlight = gameObject.GetComponentInParent<TrafficLight>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "CarAi")
        {
            CharacterNavController speed = other.gameObject.GetComponent<CharacterNavController>();
            speed.movementSpeed = 5f;
        }
    }
}
