using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyHP : MonoBehaviour
{
    public int hpShooter;
    public Progress _prog;
    public int hpBomber;

    public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {
        _prog = GameObject.Find("Panel").GetComponent<Progress>();
        hpShooter = 100;
        hpBomber = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (hpShooter <= 0 || hpBomber <= 0 )
        {
            _prog.Prog.fillAmount += 0.05f;
            if (_prog.PrefLvl >= 15)
            {
                _prog.kolvo += 1;
            }
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect,1f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Bullet")
        {
            if (gameObject.name == "Shooter")
            {
                hpShooter -= Random.Range(35, 55);
                Destroy(col.gameObject);
            }

            if (gameObject.name == "Bomber")
            {
                hpBomber -= Random.Range(35, 45);
                Destroy(col.gameObject);
            }
        }
        if (col.name == "Raketa")
        {
            if (gameObject.name == "Shooter")
            {
                hpShooter -= 55;
                Destroy(col.gameObject);
            }

            if (gameObject.name == "Bomber")
            {
                hpBomber -= 55;
                Destroy(col.gameObject);
            }
        }
        if (col.name == "Shield")
        {
            if (gameObject.name == "Shooter")
            {
                hpShooter -= 65;
            }

            if (gameObject.name == "Bomber")
            {
                hpBomber -= 50;
            }
        }
    }
}
