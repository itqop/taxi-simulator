using UnityEngine;


//! DVIZENIE PED
public class PedCharContr : MonoBehaviour
{
    public float movementSpeed = 1;
    public float rotationSpeed = 120;
    public float stopDistance = 2f;
    public Vector3 destination;
    public bool reachedDestination;

    private Vector3 lastPos;
    private Vector3 velocity;

    private void Awake()
    {
        movementSpeed = Random.Range(0.8f, 1.5f);
    }

    private void Update()
    {
        if (transform.position != destination)
        {
            Vector3 destinationDir = destination - transform.position;
            destinationDir.y = 0;
            float destinationDestance = destinationDir.magnitude;
            if (destinationDestance >= stopDistance)
            {
                reachedDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDir);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation,rotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            else
            {
                reachedDestination = true;
            }

            velocity = (transform.position - lastPos) / Time.deltaTime;
            velocity.y = 0;
            var velocityMagn = velocity.magnitude;
            velocity = velocity.normalized;
            var fwdDotProduct = Vector3.Dot(transform.forward, velocity);
            var rightDotProduct = Vector3.Dot(transform.right, velocity);
        }

        lastPos = transform.position;
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        reachedDestination = false;
    }
}
