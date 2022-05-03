using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody2D _player;
    public Vector2 movement;
    public float speed;
    public float offset = 5f;
    public PauseMenu _Pause;
    private void Start()
    {
        _player = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_Pause.time == 0)
        {
           movement.x = Input.GetAxis("Horizontal");
           movement.y = Input.GetAxis("Vertical"); 
        }


        MouseLook();
    }

    private void FixedUpdate()
    {
        if (_Pause.time == 0)
        {
            _player.MovePosition(_player.position + movement * speed * Time.fixedDeltaTime);
        }
        
    }

    private void MouseLook()
    {
        Vector2 mouePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up = mouePos - new Vector2(transform.position.x, transform.position.y);
    }
}
