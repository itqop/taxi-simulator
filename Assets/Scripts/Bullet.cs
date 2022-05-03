using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    private Rigidbody2D _ammo;
    public float Speed;
    private void Start()
    {
        _ammo = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _ammo.AddForce(transform.right * Speed* Time.fixedDeltaTime,ForceMode2D.Force);
        StartCoroutine(die());
    }
    
    IEnumerator die()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Shooter")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect,1f);
            Destroy(gameObject);
        }
        if (col.name == "Bomber")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect,1f);
            Destroy(gameObject);
        }
    }
}
