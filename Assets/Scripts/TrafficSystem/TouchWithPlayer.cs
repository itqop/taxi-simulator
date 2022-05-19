
using UnityEngine;


//! SOPRIKOSNOVENIE S IGROKOM
public class TouchWithPlayer : MonoBehaviour
{
    public pedisSpawn _pd;
    public Stats _stats;
    public Rigidbody _rb;
    private CharacterNavController _carController;
    public bool tch;
    public float kd;
    public float kd2;
    public bool tch2;
    private AnimatorChar _animator;
    private PedCharContr _charContr;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (GameObject.Find("GameManager"))
        {
            _stats = GameObject.Find("GameManager").GetComponent<Stats>(); 
        }
        _carController = GetComponent<CharacterNavController>();
        _animator = GetComponent<AnimatorChar>();
        if (gameObject.name == "pedestrian")
        {
            _charContr = GetComponent<PedCharContr>();
        }
        kd = 2;
        kd2 = 2;
    }

    private void Update()
    {
        if (tch)
        {
            kd -= Time.deltaTime;
            if (kd > 0)
            {
                _carController.movementSpeed = 0;
                _rb.velocity = Vector3.zero;
            }
            else
            {
                tch = false;
                kd = 2;
            }
        }

        if (gameObject.name == "pedestrian")
        {
            if (tch2)
            {
                kd2 -= Time.deltaTime;
                if (kd2 > 0)
                {
                    _charContr.movementSpeed = 0;
                    _rb.isKinematic = false;
                    _rb.AddForce(Vector3.up * 60f,ForceMode.Force);
                    _animator.animHit();
                }
                else
                {
                    Destroy(gameObject);
                    _pd.count -= 1;
                }
            }
            else
            {
                _animator.animWalk();
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.name == "CarAi")
        {
            if (collision.gameObject.name == "Car")
            {
                _stats.Money -= 100;
            
                tch = true;
            }
        }
        
        if (gameObject.name == "pedestrian")
        {
            if (collision.gameObject.name == "Car")
            {
                _stats.Money -= 200;
                
                tch2 = true;
            }
        }
    }
}
