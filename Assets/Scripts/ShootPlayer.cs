using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public Transform startPoint;
    public GameObject bulletPref;
    public float _range = 20f;
    public GameObject hitEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            var hit = Physics2D.Raycast(startPoint.position,transform.up,_range);

            var trail = Instantiate(bulletPref, startPoint.position, transform.rotation);

            var trailScript = trail.GetComponent<BulletTrail>();
            Debug.Log(trailScript);
            
            if (hit.collider != null)
            {
                trailScript.SetTargetPosition(hit.point);
                var hittable = hit.collider.GetComponent<EnemyHP>();
                if (hit.collider.name == "Bomber")
                {
                    GameObject effect = Instantiate(hitEffect, hit.collider.transform.position, hit.collider.transform.rotation);
                    Destroy(effect,1f);
                    hittable.hpBomber -= 50;
                }

                if (hit.collider.name == "Shooter")
                {
                    GameObject effect2 = Instantiate(hitEffect, hit.collider.transform.position, hit.collider.transform.rotation);
                    Destroy(effect2,1f);
                    hittable.hpShooter -= Random.Range(10,40);
                }
                    
            }
            else
            {
                var endPos = startPoint.position + transform.up * _range;
                trailScript.SetTargetPosition(endPos);
            }
        }
    }
}
