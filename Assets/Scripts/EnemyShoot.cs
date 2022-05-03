using UnityEngine;
using UnityEngine.UI;

public class EnemyShoot : MonoBehaviour
{
    public Transform player;

    public float speed = 35f;

    public Vector2 target;
    
    public Progress _progStat;

    public PauseMenu _Pause;

    public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        _Pause = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        _progStat = GameObject.Find("Panel").GetComponent<Progress>();
        speed = 35f;
        player = GameObject.Find("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_Pause.time == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position,target,speed * Time.fixedDeltaTime);
            
            if ((Vector2)transform.position == target)
            {
                GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
                Destroy(effect,1f);
                Destroy(gameObject);
            } 
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            _progStat.Prog.fillAmount -= 0.1f;
            if (_progStat.Prog.fillAmount == 0)
            {
                _progStat.check = true;
            }
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect,1f);
            Destroy(gameObject);
        }

        if (col.name == "Shield")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect,1f);
            Destroy(gameObject);
        }
    }
}
