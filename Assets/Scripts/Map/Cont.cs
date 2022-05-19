using UnityEngine;

public class Cont : MonoBehaviour {

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public bool startCar;
    public bool checkEvents;
    public float breakForce = 5000;
    public ParticleSystem[] _smoke;
    private Rigidbody m_Rigidbody;
    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle = 30;
    public float startMotorForce = 800;
    public float motorForce;
    public Stats _stats;
    public bool StopLightIntens;
    public float stopSpeed = 0.99f;
    
    //! PRISVOENIE OBJECTOV.
    private void Start()
    {
        startCar = false;
        StopLightIntens = false;
        m_Rigidbody = GetComponent<Rigidbody>();
        _stats = GameObject.Find("GameManager").GetComponent<Stats>();
    }

    //! GET ASIX.    
    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    
    //! ANGLE STEER .
    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;
    }

    //! YSKORENIE.    
    private void Accelerate()
    {
        if (_stats.CurrentFuel > 0)
        {
            motorForce = startMotorForce;
        }
        else
        {
            motorForce = 0;
        }

        rearPassengerW.motorTorque = m_verticalInput * motorForce;
        rearDriverW.motorTorque = m_verticalInput * motorForce;
    }

    //! KRY4ENIE KOLES.
    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    //! KRY4ENIE KOLES.
    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    //! YPRAVLENIE CAR.
    private void Update()
    {
        if (Input.GetButtonUp("StartCar"))
        {
            startCar = !startCar;                
        }

        if (startCar)
        {
            for (int i = 0; i < _smoke.Length; i++)
            {
                if (_smoke[i].isStopped)
                {
                    _smoke[i].Play(); 
                }
            }

            
            Accelerate();
        }
        else
        {
            for (int i = 0; i < _smoke.Length; i++)
            {
                if (_smoke[i].isPlaying)
                {
                    _smoke[i].Stop(); 
                }
            }
            Vector3 vel = m_Rigidbody.velocity;
            m_Rigidbody.velocity *= stopSpeed;
            if (m_Rigidbody.velocity.magnitude < 1.5f)
            {
                m_Rigidbody.velocity = vel.normalized * 0;
            }
        }
    }

    //! SKOROST MASHIN AND TORMOZZZ.
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        UpdateWheelPoses(); 
        if (PlayerPrefs.GetInt("CurrentCar") == 0)
        {
            if (m_Rigidbody.velocity.magnitude > 13f)
            {
                m_Rigidbody.velocity = m_Rigidbody.velocity.normalized * 13f;
            }
        }
        
        if (PlayerPrefs.GetInt("CurrentCar") == 1)
        {
            if (m_Rigidbody.velocity.magnitude > 18f)
            {
                m_Rigidbody.velocity = m_Rigidbody.velocity.normalized * 18f;
            }
        }
        
        if (PlayerPrefs.GetInt("CurrentCar") == 2)
        {
            if (m_Rigidbody.velocity.magnitude > 23f)
            {
                m_Rigidbody.velocity = m_Rigidbody.velocity.normalized * 23f;
            }
        }
        
        if (Input.GetButton("Jump") || checkEvents )
        {
            ApplyBreaking();
        }
        else
        {
            DisableBreaking();
        }
    }
    
    //! TORMOZZ ACTIV
    private void ApplyBreaking()
    {
        m_Rigidbody.drag = 1;
        StopLightIntens = true;
        rearDriverW.brakeTorque = breakForce;
        rearPassengerW.brakeTorque = breakForce;
        rearDriverW.motorTorque = 0;
        rearPassengerW.motorTorque = 0;
    }
    
    //! TORMOZZ DIZAKTIV
    private void DisableBreaking()
    {
        m_Rigidbody.drag = 0.08f;
        StopLightIntens = false;
        rearDriverW.brakeTorque = 0;
        rearPassengerW.brakeTorque = 0;
    }
}