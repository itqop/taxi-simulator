using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    private Vector3 startPos;

    private Vector3 targetPos;

    private float prog;

    [SerializeField] private float _speed = 40f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.WithAxis(Axis.Z, -1);
    }

    // Update is called once per frame
    void Update()
    {
        prog += Time.deltaTime * _speed;
        transform.position = Vector3.Lerp(startPos, targetPos, prog);
        
    }

    public void SetTargetPosition(Vector3 targetPoss)
    {
        targetPos = targetPoss.WithAxis(Axis.Z, -1);
    }
}
