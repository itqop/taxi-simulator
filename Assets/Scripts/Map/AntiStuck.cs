using UnityEngine;
public class AntiStuck : MonoBehaviour
{
    public Transform wheelModel;
    public int raysNum = 36;
    public float raysMaxAngle = 180f;
    public float wheelWidth = 0.15f;
    public Cont _Collider;
    
    private WheelCollider _wheelCollider;
    private float orgRadius;
    private void Awake()
    {
        _wheelCollider = GetComponent<WheelCollider>();
        orgRadius = _wheelCollider.radius;
        _Collider = GetComponentInParent<Cont>();
    }

    //! antistuck system koles
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float radiusOffset = 0f;
        for (int i = 0; i <= raysNum; i++)
        {
            Vector3 rayDir = Quaternion.AngleAxis(_wheelCollider.steerAngle,transform.up) * 
                             Quaternion.AngleAxis(i * (raysMaxAngle / raysNum) + ((180f - raysMaxAngle)/2f) ,transform.right) 
                             * transform.forward;
            if (Physics.Raycast(wheelModel.position, rayDir, out RaycastHit hit, _wheelCollider.radius))
            {
                if (!hit.transform.IsChildOf(_Collider.transform) && !hit.collider.isTrigger){
                    Debug.DrawLine(wheelModel.position, hit.point, Color.red);
                    radiusOffset = Mathf.Max(radiusOffset, _wheelCollider.radius - hit.distance);
                }
            }
            Debug.DrawRay(wheelModel.position,rayDir * orgRadius,Color.green);
            
            if (Physics.Raycast(wheelModel.position + wheelModel.right * wheelWidth * .5f, rayDir, out RaycastHit hitR, _wheelCollider.radius))
            {
                if (!hitR.transform.IsChildOf(_Collider.transform) && !hitR.collider.isTrigger){
                   Debug.DrawLine(wheelModel.position + wheelModel.right * wheelWidth * .5f , hitR.point, Color.red);
                   radiusOffset = Mathf.Max(radiusOffset, _wheelCollider.radius - hitR.distance); 
                }
            }
            Debug.DrawRay(wheelModel.position + wheelModel.right * wheelWidth * .5f,rayDir * orgRadius,Color.green);
            
            if (Physics.Raycast(wheelModel.position - wheelModel.right * wheelWidth * .5f, rayDir, out RaycastHit hitL, _wheelCollider.radius))
            {
                if (!hitL.transform.IsChildOf(_Collider.transform) && !hitL.collider.isTrigger){
                   Debug.DrawLine(wheelModel.position - wheelModel.right * wheelWidth * .5f, hitL.point, Color.red);
                   radiusOffset = Mathf.Max(radiusOffset, _wheelCollider.radius - hitL.distance); 
                }
            }
            Debug.DrawRay(wheelModel.position - wheelModel.right * wheelWidth * .5f,rayDir * orgRadius,Color.green);
        }
        
        //_wheelCollider.radius = Mathf.Lerp(_wheelCollider.radius, orgRadius + radiusOffset, 0.1f);
        _wheelCollider.radius = Mathf.LerpUnclamped(_wheelCollider.radius, orgRadius + radiusOffset, Time.deltaTime * 15f);
    }
}
