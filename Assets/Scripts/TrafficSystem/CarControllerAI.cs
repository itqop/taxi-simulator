using System;
using UnityEngine;
using Random = UnityEngine.Random;

//!  YPRAVLENIE MASHINI AI
public class CarControllerAI : MonoBehaviour
{
    public CharacterNavController _controller;
    public WayPoint currentWayPoint;
    [SerializeField]
    public float prevMoveSpeed;
    
    private RaycastHit hit;
    private bool pd;
    private void Awake()
    {
        _controller = GetComponent<CharacterNavController>();
        prevMoveSpeed = _controller.movementSpeed;
    }

    private void Start()
    {
        _controller.SetDestination(currentWayPoint.GetPosition());
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 4f,layerMask:3)){
            if (hit.collider.name == "CarAi")
            {
                CharacterNavController car = hit.collider.gameObject.GetComponent<CharacterNavController>();
                _controller.movementSpeed = car.movementSpeed - 0.5f;
                Rigidbody  owncar = GetComponent<Rigidbody>();
                Rigidbody forwardcar = hit.collider.gameObject.GetComponent<Rigidbody>();
                owncar.velocity = forwardcar.velocity;
            }
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f))
        {
            if (hit.collider.name == "Car")
            {
                Rigidbody  owncar = GetComponent<Rigidbody>();
                owncar.velocity = Vector3.zero;
                _controller.movementSpeed = 0;
            }
        }

        if (hit.collider == null & !pd)
        {
            _controller.movementSpeed = prevMoveSpeed;
        }
        if (_controller.reachedDestination)
        {
            bool shouldBranch = false;

            if (currentWayPoint.branches != null && currentWayPoint.branches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWayPoint.branchRatio ? true : false;
            }

            if (shouldBranch)
            {
                currentWayPoint = currentWayPoint.branches[Random.Range(0, currentWayPoint.branches.Count - 1)];
            }
            else
            {
               
                if (currentWayPoint.nextWaypoint != null)
                {
                    currentWayPoint = currentWayPoint.nextWaypoint;
                }
            }
            
            _controller.SetDestination(currentWayPoint.GetPosition());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == "PD")
        {
            pd = true;
            TrafficLight tl = other.GetComponent<TrafficLight>();
            
            Rigidbody car = GetComponent<Rigidbody>();

            if (!tl.trafficLight & other.name != "checkcar")
            {
                if (tl.noPed)
                {
                    _controller.movementSpeed = 0;
                    car.velocity = Vector3.zero;
                }
                _controller.movementSpeed = 0;
                car.velocity = Vector3.zero;
            }
            
            if (tl.trafficLight & !tl.noPed)
            {
                _controller.movementSpeed = prevMoveSpeed;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pd = false;
    }
}
